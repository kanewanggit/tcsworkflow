using System.Collections.Generic;
using System.Reflection;
using Base.ActivityInterface;
using Base.Dto;
using BusinessLogic.Manager;
using CoreImplementation;
using CoreImplementation.Validator;
using FluentValidation;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;

namespace BusinessLogic
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
                Assembly.GetAssembly(typeof (CoreFlowProvider)),
                Assembly.GetAssembly(typeof (EmailFlowManager))
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
