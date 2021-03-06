﻿using Base.ActivityInterface;
using Base.Dto;

namespace MbImplementation
{
    public class CoreFlowProvider: ICoreFlowProvider
    {
        public ActivityOutput SendEmail(EmailDto dto)
        {
            return new ActivityOutput() { Status = Base.Constant.Status.Sent, Successful = true, Message = "MB Implementation" };
        }
    }
}
