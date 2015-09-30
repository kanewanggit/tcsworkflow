using System;
using System.Activities;
using Base;
using Base.Dto;
using Base.ManagerInterface;
using Workflow;

namespace BusinessLogic.Manager
{
    public class EmailFlowManager: IEmailFlowManager
    {
        public Guid? InitEmailFlow(EmailDto dto)
        {
            var flowInput = new WorkFlowInput()
            {
                Email = dto,
                IsNewRequest = true
            };

            var workflow = new FlowHost();
            workflow.OnWfCompleted += workflow_OnWfCompleted;
            workflow.OnWfError += workflow_OnWfError;
            workflow.OnIdle += workflow_OnIdle;
            var workflowId = workflow.CreateOrResume(flowInput);
            return workflowId;
        }

        private void workflow_OnIdle(WorkflowApplicationIdleEventArgs e)
        {
            var output = "Bookmark created, waiting for input";
        }

        private void workflow_OnWfError(WorkflowApplicationUnhandledExceptionEventArgs e)
        {
            var output = "Error Happened, message: " + e.UnhandledException.Message;
        }

        private void workflow_OnWfCompleted(WorkflowApplicationCompletedEventArgs e)
        {
            var output = string.Empty;

            var dto = e.Outputs["Result"] as FlowStatusDto;

            if (dto != null)
            {
                foreach (var item in dto.Steps)
                {
                    output += "Status: " + item.Status + ", Successful: " + item.Successful.ToString() + ", Message: " + item.Message + "<br/>";
                }
            }
        }

        public void ResumeEmailFlow(string bookmarkName, string instanceId)
        {
            var workflow = new FlowHost();
            workflow.OnWfCompleted += workflow_OnWfCompleted;
            workflow.OnWfError += workflow_OnWfError;
            var flowInput = new WorkFlowInput()
            {
                Email = null,
                IsNewRequest = false,
                BookmarkName = bookmarkName,
                InstanceId = Guid.Parse(instanceId)
            };

            workflow.CreateOrResume(flowInput);

        }
    }
}
