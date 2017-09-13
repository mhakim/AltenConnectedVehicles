using Application;
using Application.Interfaces;
using DataAccess;
using DataAccess.Interfaces;
using DataAccess.Shared;
using DataAccess.Shared.Interfaces;
using Db;
using Resources;
using SimpleInjector;
using SimpleInjector.Extensions.ExecutionContextScoping;
using SimpleInjector.Lifestyles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSimulator
{
    public static class DiManager
    {
        static DiManager()
        {
            Container = new Container();
            Container.Options.DefaultScopedLifestyle =  new AsyncScopedLifestyle();
            InitializeContainer(Container);

            Container.Verify();
        }

        public static Container Container { get; private set; }
        
        private static void InitializeContainer(Container container)
        {
            container.Register<Context, Context>(Lifestyle.Scoped);
            container.Register<IUnitOfWork, UnitOfWork>(Lifestyle.Scoped);
            container.Register<IVehicleService, VehicleService>(Lifestyle.Scoped);
            container.Register<IVehicleRepository, VehicleRepository>(Lifestyle.Scoped);
            container.Register<IValidator<VehicleResource>, VehicleValidator>(Lifestyle.Scoped);
        }
    }

}
