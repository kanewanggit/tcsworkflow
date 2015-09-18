using System;
using System.Collections.Generic;

namespace Base.Dto
{
    [Serializable]
    public class FlowStatusDto
    {
        public List<ActivityOutput> Steps { set; get; }
    }
}
