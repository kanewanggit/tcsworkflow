using System;
using System.Activities;
using Base.ActivityInterface;
using Microsoft.Practices.ServiceLocation;

namespace WorkflowActivityLibrary.Activity
{
    public class NeedConfirmation : CodeActivity
    {
        public OutArgument<Boolean> IsSkip { set; get; }

        protected override void Execute(CodeActivityContext context)
        {
            var provider = ServiceLocator.Current.GetInstance<IFlowExtensionProvider>();

            var output = provider.NeedConfirmation();

            context.SetValue(IsSkip, !output);

        }
    }
}
