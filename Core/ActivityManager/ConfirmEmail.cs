using System.Activities;
using System.Collections.Generic;
using Base.ActivityInterface;
using Base.Dto;
using Microsoft.Practices.ServiceLocation;

namespace ActivityManager
{
    public class ConfirmEmail : CodeActivity
    {
        public InArgument<EmailDto> Dto { set; get; }
        public OutArgument<FlowStatusDto> ActivityOutput { set; get; }

        protected override void Execute(CodeActivityContext context)
        {
            var provider = ServiceLocator.Current.GetInstance<IFlowExtensionProvider>();

            var dto = context.GetValue(Dto);

            var output = provider.ConfirmEmail(dto);
            var item = new FlowStatusDto() {Steps = new List<ActivityOutput>()};
            if (output != null)
                item.Steps.Add(output);

            context.SetValue(ActivityOutput, item);

        }
    }
}
