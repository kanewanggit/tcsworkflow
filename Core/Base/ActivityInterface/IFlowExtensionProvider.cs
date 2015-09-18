using Base.Dto;

namespace Base.ActivityInterface
{
    public interface IFlowExtensionProvider
    {
        ActivityOutput ConfirmEmail(EmailDto dto);
        bool NeedConfirmation();
    }
}
