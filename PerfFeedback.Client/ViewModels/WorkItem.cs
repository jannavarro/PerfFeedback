using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PerfFeedback.Client.ViewModels
{
    [DataContract(Namespace = "http://perf.com/perf")]
    public class WorkItem : ViewModel
    {
        [DataMember]
        public string Id { get; set; }
        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public Strength Strength { get; set; }

        [DataMember]
        public AreaForImprovement AreaForImprovement { get; set; }

        public WorkItem()
        {
            Title = string.Empty;
            Strength = new Strength();
            AreaForImprovement = new AreaForImprovement();
        }

        public WorkItem(WorkItem copy)
        {
            Id = copy.Id;
            Title = copy.Title;
            Strength = new Strength(copy.Strength);
            AreaForImprovement = new AreaForImprovement(copy.AreaForImprovement);
        }
    }
}
