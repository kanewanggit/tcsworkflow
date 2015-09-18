using System;

namespace Base.Dto
{
    [Serializable]
    public class WorkFlowInput
    {
        public EmailDto Email { set; get; }
        public bool IsNewRequest { set; get; }
        public int Province { set; get; }
        public string BookmarkName { set; get; }
        public Guid? InstanceId { set; get; }
    }
}
