using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PerfFeedback.Client.ViewModels
{
    [DataContract(Namespace = "http://perf.com/perf")]
    public class Feedback : ViewModel
    {
        [DataMember]
        public long FeedbackId { get; set; }

        [DataMember]
        public string Comment { get; set; }

        [DataMember]        
        public long WorkItemId { get; set; }
    }
}
