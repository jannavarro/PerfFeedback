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
    public class WorkItem
    {
        [DataMember]
        [Key, Column(Order = 0), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long WorkItemId { get; set; }
        [DataMember]
        [Key, Column(Order=1)]
        public string Title { get; set; }
        [DataMember]
        public Strength Strength { get; set; }

        [DataMember]
        public AreaForImprovement AreaForImprovement { get; set; }

        public long? Strength_FeedbackId { get; set; }
        public long? AreaForImprovement_FeedbackId { get; set; }

    }
}
