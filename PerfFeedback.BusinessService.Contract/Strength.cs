using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PerfFeedback.BusinessService.Contract
{
    [DataContract(Namespace = "http://perf.com/perf")]
    public class Strength : Feedback
    {
    }
}
