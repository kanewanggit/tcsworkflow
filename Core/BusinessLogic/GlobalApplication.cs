using System.Web.Mvc;
using FluentValidation.Mvc;

namespace BusinessLogic
{
    public class GlobalApplication : System.Web.HttpApplication
    {
        protected virtual void Application_Start()
        {
            //Tell MVC to use FV for validation
            var factory = new ValidatorProvider();
            ModelValidatorProviders.Providers.Add(new FluentValidationModelValidatorProvider(factory));
            DataAnnotationsModelValidatorProvider.AddImplicitRequiredAttributeForValueTypes = false;

            // FluentValidationModelValidatorProvider.Configure();

            UnityRegistration.Register();
        }

    }
}
