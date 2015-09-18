using Base.Dto;

namespace Base.ActivityInterface
{
    public interface ICoreFlowProvider
    {
        ActivityOutput SendEmail(EmailDto dto);
    }
}
