using System.Collections.Generic;
using System.Reflection;
using System.Web.Optimization;
using Base.ActivityInterface;
using Base.Dto;
using CoreImplementation;
using CoreImplementation.Validator;
using FluentValidation;
using Microsoft.Practices.Unity;
using WebCoreLibrary;
using WorkflowActivityLibrary;

namespace CoreWeb
{
    public class MvcApplication : GlobalApplication
    {
        protected override void Application_Start()
        {
            base.Application_Start();

            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // Overwrite implementation
            var container = UnityRegistration.Container;
            var assemblyList = new List<Assembly> {
                Assembly.GetAssembly(typeof (ICoreFlowProvider)), 
                Assembly.GetAssembly(typeof (CoreFlowProvider))
            };

            container.RegisterTypes(AllClasses.FromAssemblies(assemblyList), WithMappings.FromMatchingInterface,
                WithName.Default,
                WithLifetime.ContainerControlled, null, true);  // overwrite core implementation

            // Overwrite validation
            container.RegisterType<IValidator<EmailDto>, EmailValidator>(new TransientLifetimeManager());

        }
    }
}
