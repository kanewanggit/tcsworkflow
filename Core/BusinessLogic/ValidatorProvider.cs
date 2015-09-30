using System;
using FluentValidation;
using Microsoft.Practices.ServiceLocation;

namespace BusinessLogic
{
    public class ValidatorProvider : ValidatorFactoryBase
    {
        public override IValidator CreateInstance(Type validatorType)
        {
            return ServiceLocator.Current.GetInstance(validatorType) as IValidator;

        }
    }
}
