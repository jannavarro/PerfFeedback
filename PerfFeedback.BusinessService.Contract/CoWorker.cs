using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PerfFeedback.BusinessService.Contract
{
    [DataContract(Namespace="http://perf.com/perf")]
    public class CoWorker
    {
        [DataMember]
        [Key, Column(Order = 0), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long CoWorkerId { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public List<WorkItem> WorkItems { get; set; }

        public CoWorker()
        {

        }
    }
}
