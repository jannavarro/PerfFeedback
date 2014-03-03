using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PerfFeedback.Client.ViewModels
{
    [DataContract(Namespace = "http://perf.com/perf")]
    public class Strength : Feedback
    {
        public Strength()
        {

        }

        public Strength(Strength copy)
        {
            ID = copy.ID;
            Comment = copy.Comment;
        }
    }
}
