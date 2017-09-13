[assembly: WebActivator.PostApplicationStartMethod(typeof(Apis.App_Start.SimpleInjectorWebApiInitializer), "Initialize")]

namespace Apis.App_Start
{
    using System.Web.Http;
    using SimpleInjector;
    using SimpleInjector.Integration.WebApi;
    using Application.Interfaces;
    using Resources;
    using DataAccess.Interfaces;
    using DataAccess;
    using Db;
    using Application;
    using DataAccess.Shared.Interfaces;
    using DataAccess.Shared;

    public static class SimpleInjectorWebApiInitializer
    {
        /// <summary>Initialize the container and register it as Web API Dependency Resolver.</summary>
        public static void Initialize()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebApiRequestLifestyle();
            
            InitializeContainer(container);

            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);
       
            container.Verify();
            
            GlobalConfiguration.Configuration.DependencyResolver =
                new SimpleInjectorWebApiDependencyResolver(container);
        }
     
        private static void InitializeContainer(Container container)
        {
            container.Register<Context, Context>(Lifestyle.Scoped);
            container.Register<IUnitOfWork, UnitOfWork>(Lifestyle.Scoped);
            container.Register<ICustomerService, CustomerService>(Lifestyle.Scoped);
            container.Register<IVehicleService, VehicleService>(Lifestyle.Scoped);
            container.Register<ICustomerRepository, CustomerRepository>(Lifestyle.Scoped);
            container.Register<IVehicleRepository, VehicleRepository>(Lifestyle.Scoped);
            container.Register<IValidator<CustomerResource>, CustomerValidator>(Lifestyle.Scoped);
            container.Register<IValidator<VehicleResource>, VehicleValidator>(Lifestyle.Scoped);
        }
    }
}