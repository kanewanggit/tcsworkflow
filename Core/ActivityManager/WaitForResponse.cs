using System.Activities;

namespace ActivityManager
{
    public class WaitForResponse<TResult> : NativeActivity<TResult>
    {
        public string ResponseName { get; set; }

        protected override bool CanInduceIdle
        {
            //override when the custom activity is allowed to make he workflow go idle
            get { return true; }
        }

        protected override void Execute(NativeActivityContext context)
        {
            context.CreateBookmark(ResponseName, ReceivedResponse);
        }

        private void ReceivedResponse(NativeActivityContext context, Bookmark bookmark, object obj)
        {
            Result.Set(context, (TResult) obj);
        }
    }
}

