using System;

namespace Base.Dto
{
    [Serializable]
    public class EmailDto
    {
        public string From { set; get; }
        public string Subject { set; get; }
        public string To { set; get; }
        public string Content { set; get; }
        public string SmtpServer { set; get; }
        public int Port { set; get; }

    }
}
