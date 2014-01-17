using PerfFeedback.BusinessService.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfFeedback.Client.Models
{
    public class CoWorkerModel : Model<CoWorker, CoWorkerViewModel>
    {
        private CoWorkerService.CoWorkerServiceClient _service;

        public CoWorkerService.CoWorkerServiceClient Service
        {
            get
            {
                if (_service == null)
                {
                    _service = new CoWorkerService.CoWorkerServiceClient();
                }

                return _service;
            }
            set { _service = value; }
        }

        protected override void OnCommit(CoWorker commitItem)
        {
            Service.CommitCoWorker(commitItem);
        }
    }
}
