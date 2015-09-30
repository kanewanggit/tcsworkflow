using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Base.Dto;
using BusinessLogic;
using FluentValidation;
using Microsoft.Practices.Unity;
using Web.Validator;

namespace Web
{
    public class MvcApplication : GlobalApplication
    {
        protected override void Application_Start()
        {
            base.Application_Start();

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // Overwrite implementation including activities and all business logic
            var container = UnityRegistration.Container;
            //var assemblyList = new List<Assembly> {
            //    Assembly.GetAssembly(typeof (ICoreFlowProvider)), 
            //    Assembly.GetAssembly(typeof (CoreFlowProvider))
            //};
            //container.RegisterTypes(AllClasses.FromAssemblies(assemblyList), WithMappings.FromMatchingInterface,
            //    WithName.Default,
            //    WithLifetime.ContainerControlled, null, true);  // overwrite core implementation

            // Overwrite validation
            container.RegisterType<IValidator<EmailDto>, EmailValidator>(new TransientLifetimeManager());

        }
    }
}
