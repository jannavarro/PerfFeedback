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
    public class PerformancePeriod
    {
        [DataMember]
        [Key, Column(Order = 0), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long PerformancePeriodId { get; set; }

        [DataMember]
        public long CoWorkerId { get; set; }

        [DataMember]
        public virtual List<CoWorker> CoWorker { get; set; }

        public PerformancePeriod()
        {

        }
    }
}
