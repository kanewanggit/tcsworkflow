using System;
using Base.Dto;

namespace Base.ManagerInterface
{
    public interface IEmailFlowManager
    {
        Guid? InitEmailFlow(EmailDto dto);
        void ResumeEmailFlow(string bookmarkName, string instanceId);
    }
}
