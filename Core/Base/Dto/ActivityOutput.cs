using System;

namespace Base.Dto
{
    [Serializable]
    public class ActivityOutput
    {
        public string InstanceId { get; set; }
        public Constant.Status Status { set; get; }

        public bool Successful { set; get; }
        public string Message { set; get; }
        public DateTime StartTime { set; get; }
        public DateTime CompleteTime { set; get; }
    }
}
