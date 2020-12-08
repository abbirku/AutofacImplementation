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
