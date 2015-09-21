using System.Activities;
using Base.ActivityInterface;
using Base.Dto;
using Microsoft.Practices.ServiceLocation;

namespace WorkflowActivityLibrary.Activity
{
    public class SendEmail : CodeActivity
    {
        public InArgument<EmailDto> Dto { set; get; }
        public InOutArgument<FlowStatusDto> ActivityOutput { set; get; }

        // If your activity returns a value, derive from CodeActivity<TResult>
        // and return the value from the Execute method.
        protected override void Execute(CodeActivityContext context)
        {
            var provider = ServiceLocator.Current.GetInstance<ICoreFlowProvider>(); 
            var dto = context.GetValue(Dto);
            var item = context.GetValue(ActivityOutput);

            var output = provider.SendEmail(dto);
            if (output != null)
                item.Steps.Add(output);

            context.SetValue(ActivityOutput, item);

            //throw new Exception("Test");
        }

    }
}
