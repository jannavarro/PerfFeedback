using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PerfFeedback.BusinessService.Contract
{
    [DataContract(Namespace = "http://perf.com/perf")]
    public class Feedback
    {
        [DataMember]
        [Key, Column(Order = 0), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long FeedbackId { get; set; }

        [DataMember]
        public string Comment { get; set; }

        public long WorkItemId { get; set; }

        public Feedback()
        {
            Comment = string.Empty;
        }
    }
}
