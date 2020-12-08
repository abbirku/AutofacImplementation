using Autofac;
using Core.Repositories;
using Core.Services;
using Infrastructure.Context;
using Infrastructure.Repositories;
using Infrastructure.Services;

namespace Infrastructure
{
    public class InfrastructureModule : Module
    {
        private readonly int _minVal;
        private readonly int _maxVal;

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

        public InfrastructureModule(int minVal, int maxVal)
        {
            _minVal = minVal;
            _maxVal = maxVal;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<OfferContext>()
                .WithParameter("minVal", _minVal) //It will be connectionString
                .WithParameter("maxVal", _maxVal) //It will be migrationAssemblyName
                .InstancePerLifetimeScope();

            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>))
                .SingleInstance();

            builder.RegisterType<SpecialOfferService>().As<ISpecialOfferService>()
                .InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}
