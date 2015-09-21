using System;
using System.Activities;
using System.Web.UI.WebControls;
using Base;
using Base.Dto;
using Workflow;

namespace CoreWeb
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void RunFlow(object sender, CommandEventArgs e)
        {
            var dto = new EmailDto()
            {
                Subject = "Title",
                Content = "Content",
                From = "kanewang@live.com",
                To = "kwang@bayleaf.com"
            };

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
            if (workflowId.HasValue)
                instanceId.Value = workflowId.Value.ToString();
        }

        void workflow_OnIdle(WorkflowApplicationIdleEventArgs e)
        {
            var output = "Bookmark created, waiting for input";
            result.Text = output;
        }

        void workflow_OnWfError(WorkflowApplicationUnhandledExceptionEventArgs e)
        {
            var output = "Error Happened, message: " + e.UnhandledException.Message;
            lbFinalResult.Text = output;
        }

        void workflow_OnWfCompleted(WorkflowApplicationCompletedEventArgs e)
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

            lbFinalResult.Text = "Final Result: " + output;
        }

        protected void ResumeFlow(object sender, CommandEventArgs e)
        {
            var guidStr = instanceId.Value;

            var workflow = new FlowHost();
            workflow.OnWfCompleted += workflow_OnWfCompleted;
            workflow.OnWfError += workflow_OnWfError;
            var flowInput = new WorkFlowInput()
            {
                Email = null,
                IsNewRequest = false,
                BookmarkName = Constant.Bookmark.WaitforConfirmation,
                InstanceId = Guid.Parse(guidStr)
            };

            workflow.CreateOrResume(flowInput);

        }
    }
}