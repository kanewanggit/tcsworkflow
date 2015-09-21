using System;
using System.Activities;
using System.Activities.DurableInstancing;
using System.Collections.Generic;
using System.Threading;
using System.Web.Configuration;
using Base.Dto;

namespace Workflow
{
    public delegate void OnWfCompleted(WorkflowApplicationCompletedEventArgs e);
    public delegate void OnWfError(WorkflowApplicationUnhandledExceptionEventArgs e);
    public delegate void OnIdle(WorkflowApplicationIdleEventArgs e);

    public class FlowHost
    {
        public event OnWfCompleted OnWfCompleted;
        public event OnWfError OnWfError;
        public event OnIdle OnIdle;

        readonly AutoResetEvent _syncEvent = new AutoResetEvent(false);


        // creates a workflow application, binds parameters, links extensions and run it
        public Guid? CreateOrResume(WorkFlowInput request)
        {
            // input parameters for the WF program
            IDictionary<string, object> inputs = new Dictionary<string, object>();
            inputs.Add("Request", request);

            var connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["WorkflowPrototype"];
            var persistStore = new SqlWorkflowInstanceStore(connectionString.ConnectionString)
            {
                InstanceCompletionAction = InstanceCompletionAction.DeleteNothing,
                InstanceLockedExceptionAction = InstanceLockedExceptionAction.AggressiveRetry,
                RunnableInstancesDetectionPeriod = new TimeSpan(0, 0, 0, 5),
                HostLockRenewalPeriod = new TimeSpan(0, 0, 0, 30),
                InstanceEncodingOption = InstanceEncodingOption.GZip
            };
            
            Activity wf = new CreditTransferFlow();

            Guid? instanceId = null;

            WorkflowApplication instance;
            if (!request.IsNewRequest && request.InstanceId.HasValue && !string.IsNullOrWhiteSpace(request.BookmarkName))
            {
                instance = new WorkflowApplication(wf);
            }
            else
            {
                instance = new WorkflowApplication(wf, inputs);
                instanceId = instance.Id;
            }

            instance.InstanceStore = persistStore;
            instance.PersistableIdle = e =>
            {
                if (OnIdle != null)
                {
                    OnIdle(e);
                }
                return PersistableIdleAction.Unload;
            };
            instance.Unloaded = (workflowApplicationEventArgs) =>
            {
                // Console.WriteLine("WorkflowApplication has Unloaded\n");
                _syncEvent.Set();
            };
            instance.Completed = (e) =>
            {
                if (OnWfCompleted != null)
                {
                    OnWfCompleted(e);
                }
                _syncEvent.Set();
            };
            instance.OnUnhandledException = (e) =>
            {
                if (OnWfError != null)
                {
                    OnWfError(e);
                }
                _syncEvent.Set();
                return UnhandledExceptionAction.Abort;
            };

            if (!request.IsNewRequest && request.InstanceId.HasValue && !string.IsNullOrWhiteSpace(request.BookmarkName)) 
            {
                instance.Load(request.InstanceId.Value);
                instance.ResumeBookmark(new Bookmark(request.BookmarkName), 1);
            }

            // add a tracking participant
            //instance.Extensions.Add(new SaveAllEventsToTestFileTrackingParticipant());

            // continue executing this instance
            instance.Run();

            _syncEvent.WaitOne();

            return instanceId;
        }

    }
}