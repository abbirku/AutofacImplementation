using Autofac;
using Infrastructure.Services;
using Infrastructure.Context;
using Infrastructure.Repositories;
using Core;
using Infrastructure.UnitOfWorks;

namespace Infrastructure
{
    public class InfrastructureModule : Module
    {
        //Note in future we will pass connectionString & migrationAssemblyName for dbContext
        //Ex:
        /** 
         * private readonly string _connectionString;
         * private readonly string _migrationAssemblyName;
         * public InfrastructureModule(string connectionString, string migrationAssemblyName)
         * {
         *      _connectionString = connectionString;
         *      _migrationAssemblyName = migrationAssemblyName;
         * }
         * protected override void Load(ContainerBuilder builder)
         * {
         *      builder.RegisterType<ShopingContext>()
         *          .WithParameter("connectionString", _connectionString)
         *          .WithParameter("migrationAssemblyName", _migrationAssemblyName)
         *          .InstancePerLifetimeScope();
         * 
         *      builder.RegisterType<ProductRepository>().As<IProductRepository>()
         *          .InstancePerLifetimeScope();
         *      builder.RegisterType<CategoryRepository>().As<ICategoryRepository>()
         *          .InstancePerLifetimeScope();
         *      builder.RegisterType<ShopingUnitOfWork>().As<IShopingUnitOfWork>()
         *          .InstancePerLifetimeScope();
         *      builder.RegisterType<PurchaseService>().As<IPurchaseService>()
         *          .InstancePerLifetimeScope();
         *  
         *      base.Load(builder);
         *  }
         */

        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;

        public InfrastructureModule(string connectionString, string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }

        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterType<ShoppingContext>()
                   .WithParameter("connectionString", _connectionString)
                   .WithParameter("migrationAssemblyName", _migrationAssemblyName)
                   .InstancePerLifetimeScope();

            //Registering repositories. We don't need to register context for EFCore
            builder.RegisterType<DBSetsCollection>().AsSelf().SingleInstance();

            //Registering repositories
            builder.RegisterType<ProductRepository>().As<IProductRepository>()
                .InstancePerLifetimeScope();

            //Registering UnitOfWorks
            builder.RegisterType<ShopUnitOfWork>().As<IShopUnitOfWork>()
                .InstancePerLifetimeScope();

            //Registering services
            builder.RegisterType<SpecialOfferService>().As<ISpecialOfferService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<ProductService>().As<IProductService>()
                .InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}
