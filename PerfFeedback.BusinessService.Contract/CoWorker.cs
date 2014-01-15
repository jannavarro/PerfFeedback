using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PerfFeedback.BusinessService.Contract
{
    [DataContract]
    public class CoWorker : MarshalByRefObject
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public virtual List<Strength> Strengths { get; set; }
        public virtual List<AreaForImprovement> AreasForImprovement { get; set; }
    }
}
