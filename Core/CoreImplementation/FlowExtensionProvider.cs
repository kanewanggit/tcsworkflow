using Base.ActivityInterface;
using Base.Dto;

namespace CoreImplementation
{
    public class FlowExtensionProvider: IFlowExtensionProvider
    {
        public ActivityOutput ConfirmEmail(EmailDto dto)
        {
            return null;
        }

        public bool NeedConfirmation()
        {
            return false;
        }
    }
}
