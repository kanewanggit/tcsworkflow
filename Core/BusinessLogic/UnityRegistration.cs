using System.Collections.Generic;
using System.Reflection;
using System.Web.UI;
using Base.ActivityInterface;
using Base.Dto;
using CoreImplementation;
using CoreImplementation.Validator;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using FluentValidation;

namespace WorkflowActivityLibrary
{
	public class UnityRegistration
	{
	    public static UnityContainer Container;

		public static void Register()
		{
			var locator = new UnityServiceLocator(ConfigureUnityContainer());
			ServiceLocator.SetLocatorProvider(() => locator);
		}

		private static IUnityContainer ConfigureUnityContainer()
		{
			Container = new UnityContainer();
		    var assemblyList = new List<Assembly> {
                Assembly.GetAssembly(typeof (ICoreFlowProvider)), 
                Assembly.GetAssembly(typeof (CoreFlowProvider))
            };

		    Container.RegisterTypes(AllClasses.FromAssemblies(assemblyList), WithMappings.FromMatchingInterface,
		        WithName.Default,
		        WithLifetime.ContainerControlled);  // default mapping - core implementation

            // Register all validators
            Container.RegisterType<IValidator<EmailDto>, EmailValidator>(new TransientLifetimeManager());

            // Load implementation from different running instance, could be differentiated by domain name
            // Overwrite Container in customization 

			return Container;
		}
	}
}
