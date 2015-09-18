using System;
using System.Collections.Generic;
using System.Reflection;
using System.Web.Configuration;
using Base;
using Base.ActivityInterface;
using CoreImplementation;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;

namespace WorkflowActivityLibrary
{
	public class UnityRegistration
	{
		public static void Register()
		{
			var locator = new UnityServiceLocator(ConfigureUnityContainer());
			ServiceLocator.SetLocatorProvider(() => locator);
		}

		private static IUnityContainer ConfigureUnityContainer()
		{
			var container = new UnityContainer();
		    var assemblyList = new List<Assembly> {
                Assembly.GetAssembly(typeof (ICoreFlowProvider)), 
                Assembly.GetAssembly(typeof (CoreFlowProvider))
            };

		    container.RegisterTypes(AllClasses.FromAssemblies(assemblyList), WithMappings.FromMatchingInterface,
		        WithName.Default,
		        WithLifetime.ContainerControlled);  // default mapping - core implementation


            // Load implementation from different running instance, could be differentiated by domain name

            //assemblyList = new List<Assembly> {
            //    Assembly.GetAssembly(typeof (ICoreFlowProvider))
            //};
            //var organization = (Constant.Province) Enum.Parse(typeof(Constant.Province), WebConfigurationManager.AppSettings[Constant.AppSettingKeys.Organization]);
            //switch (organization)
            //{
            //    case Constant.Province.BC:
            //        assemblyList.Add(Assembly.GetAssembly(typeof (BcActivityLibrary.CoreFlowProvider)));
            //        break;
            //    case Constant.Province.MB:
            //        assemblyList.Add(Assembly.GetAssembly(typeof (BcActivityLibrary.CoreFlowProvider)));
            //        break;
            //        break;
            //    default:
            //        assemblyList.Add(Assembly.GetAssembly(typeof(BcActivityLibrary.CoreFlowProvider)));
            //        break;
            //}
            //container.RegisterTypes(AllClasses.FromAssemblies(assemblyList), WithMappings.FromMatchingInterface,
            //    WithName.Default,
            //    WithLifetime.ContainerControlled, null, true);  // overwrite - BC implementation, initialized by running instance.

			return container;
		}
	}
}
