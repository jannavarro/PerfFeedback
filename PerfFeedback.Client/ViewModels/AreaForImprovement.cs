using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PerfFeedback.Client.ViewModels
{
    [DataContract(Namespace = "http://perf.com/perf")]
    public class AreaForImprovement : Feedback
    {
        public AreaForImprovement()
        {

        }

        public AreaForImprovement(AreaForImprovement copy)
        {
            ID = copy.ID;
            Comment = copy.Comment;
        }
    }
}
