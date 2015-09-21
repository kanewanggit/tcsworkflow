using Base.ActivityInterface;
using Base.Dto;

namespace MbImplementation
{
    public class FlowExtensionProvider: IFlowExtensionProvider
    {
        public ActivityOutput ConfirmEmail(EmailDto dto)
        {
            return new ActivityOutput { Status = Base.Constant.Status.Confirmed, Successful = true, Message = "MB Confirmation."};
        }

        public bool NeedConfirmation()
        {
            return true;
        }
    }
}
