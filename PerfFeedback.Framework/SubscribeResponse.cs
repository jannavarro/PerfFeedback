using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PerfFeedback.Framework
{
    public class SubscribeResponse
    {
        public Result Result { get; set; }
        public object ExpectedResponse { get; set; }
        public string ErrorMessage { get; set; }
    }
}
