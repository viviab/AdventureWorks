using System;
using System.Web;
using System.Web.Http;
using AdventureWorks.BussinesLogic.Services.Sales;
using AdventureWorks.Core.Interfaces.BussinesLogic.Services.Sales;
using AdventureWorks.Core.Interfaces.Persistance.Repositories;
using AdventureWorks.Core.Persistance.Repositories.Sales;
using AdventureWorks.UI.Api;
using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using Ninject;
using Ninject.Web.Common;
using Ninject.Web.Common.WebHost;
using AdventureWorks.Core.Persistance.Repositories.People;
using AdventureWorks.Core.Interfaces.BussinesLogic.Services.People;
using AdventureWorks.BussinesLogic.Services.Person;
using AdventureWorks.Core.Infrastructure;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(NinjectWebCommon), "Stop")]

namespace AdventureWorks.UI.Api
{
    public static class NinjectWebCommon
    {
        private static readonly Bootstrapper Bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));

            Bootstrapper.Initialize(CreateKernel);

        }

        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            Bootstrapper.ShutDown();
        }

        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var settings = new NinjectSettings() { LoadExtensions = false };
            var kernel = new StandardKernel(settings);
            try
            {

                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                kernel.Bind<ICustomersRepository>().To<CustomersRepository>();
                kernel.Bind<ICustomersGetterService>().To<CustomersGetterService>();
                kernel.Bind<ICustomersAdderService>().To<CustomersAdderService>();
                kernel.Bind<IPeopleRepository>().To<PeopleRepository>();
                kernel.Bind<IPeopleAdderService>().To<PeopleAdderService>();
                kernel.Bind<IRequestValidationService>().To<RequestValidationService>();

                GlobalConfiguration.Configuration.DependencyResolver = new NinjectDependencyCoreResolver(kernel);

                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

    }
}