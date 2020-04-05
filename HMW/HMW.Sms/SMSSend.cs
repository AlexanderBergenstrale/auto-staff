using System;

namespace Sms
{
    public class SMSSend
    {

        private string _from = "+46766862979";

        public string to { get; set; }

        public string seq { get; set; }

        public string from { get { return _from; } }

        public string created { get; set; }
        public string message { get; set; }
    }
}
