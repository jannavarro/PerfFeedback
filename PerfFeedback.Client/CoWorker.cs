using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PerfFeedback.Client.Models;

namespace PerfFeedback.Client
{
    public class CoWorkerViewModel : ItemViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<Strength> Strengths { get; set; }
        public List<AreaForImprovement> AreaForImprovement { get; set; }

        protected override void OnCommit()
        {
            CoWorkerModel.Commit(this);
        }
    }
}
