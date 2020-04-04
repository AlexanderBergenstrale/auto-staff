using System;

namespace Sms
{
    public class SMSPayload
    {
        public string direction { get; set; }

        public string id { get; set; }

        public string from { get; set; }

        public string created { get; set; }
        public string message { get; set; }
    }
}
