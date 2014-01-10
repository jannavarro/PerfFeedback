using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PerfFeedback.Client.Models;

namespace PerfFeedback.Client
{
    public class CoWorker : ItemViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        /// <summary>
        /// TODO copy from other project
        /// </summary>
        /// <value>
        /// The work item.
        /// </value>
        public CoWorkerWorkItem WorkItem { get; set; }

        protected override void OnCommit()
        {
            CoWorkerModel.CommitCoWorker(
        }
    }
}
