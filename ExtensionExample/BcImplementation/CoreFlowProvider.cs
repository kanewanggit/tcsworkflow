using Base.ActivityInterface;
using Base.Dto;

namespace BcImplementation
{
    public class CoreFlowProvider: ICoreFlowProvider
    {
        public ActivityOutput SendEmail(EmailDto dto)
        {
            return new ActivityOutput() { Status = Base.Constant.Status.Sent, Successful = true, Message = "BC Implementation" };
        }
    }
}
