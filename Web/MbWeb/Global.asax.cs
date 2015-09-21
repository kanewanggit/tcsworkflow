using System.Collections.Generic;
using System.Reflection;
using Base.ActivityInterface;
using MbImplementation;
using Microsoft.Practices.Unity;
using WebCoreLibrary;
using WorkflowActivityLibrary;

namespace MbWeb
{
    public class Global : GlobalApplication
    {
        protected override void Application_Start()
        {
            base.Application_Start();

            // Overwrite implementation
            var container = UnityRegistration.Container;
            var assemblyList = new List<Assembly> {
                Assembly.GetAssembly(typeof (ICoreFlowProvider)), 
                Assembly.GetAssembly(typeof (CoreFlowProvider))
            };

            container.RegisterTypes(AllClasses.FromAssemblies(assemblyList), WithMappings.FromMatchingInterface,
                WithName.Default,
                WithLifetime.ContainerControlled, null, true);  // overwrite core implementation
        }
    }
}