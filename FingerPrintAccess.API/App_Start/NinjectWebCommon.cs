using System.Web.Http;
using FingerPrintAccess.Data.Contexts;
using FingerPrintAccess.Data.Repositories;
using FingerPrintAccess.Data.Repositories.Base;
using FingerPrintAccess.Models.Models;
using FingerPrintAccess.Service;
using Ninject.Web.WebApi;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(FingerPrintAccess.API.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(FingerPrintAccess.API.App_Start.NinjectWebCommon), "Stop")]

namespace FingerPrintAccess.API.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                GlobalConfiguration.Configuration.DependencyResolver = new NinjectDependencyResolver(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<FingerPrintAccessContext>().ToSelf().InRequestScope();
            kernel.Bind<AbstractBaseRepository<User>>().To<UserRepository>().InRequestScope();
            kernel.Bind<IUserService>().To<UserService>().InRequestScope();

            kernel.Bind<Record>().ToSelf();
        }        
    }
}
