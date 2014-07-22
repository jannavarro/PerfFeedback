using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PerfFeedback.BusinessService.Contract;
using PerfFeedback.Client.PerfLocal;
using PerfFeedback.Framework;
using VM = PerfFeedback.Client.ViewModels;
namespace PerfFeedback.Client.Models
{
    public class WorkItemModel : Model<WorkItem, VM.WorkItem>
    {
        private CoWorkerServiceClient _service;
        public CoWorkerServiceClient Service
        {
            get
            {
                if (_service == null)
                {
                    _service = new CoWorkerServiceClient();
                }
                return _service;
            }
            set { _service = value; }
        }
        
        protected override VM.WorkItem OnCommit(WorkItem commitItem)
        {
            return OnTranslateToViewModel(Service.AddWorkItem(commitItem));
        }

        protected override void OnPublish(VM.WorkItem item)
        {
            SubscribeResponse response = new SubscribeResponse() { ExpectedResponse = item, StatusResult = Framework.Result.Success };
            TempEventBus.Publish("CommitWorkItem", response);
        }

        protected override List<VM.WorkItem> OnGetAll()
        {
            throw new NotImplementedException();
        }

        protected override VM.WorkItem OnGet(long id, List<object> obj)
        {
            //var coWorker = Service.GetCoWorker(id);
            //return OnTranslateToViewModel(coWorker);
            return null;
        }

        protected override VM.WorkItem OnUpdate(WorkItem commitItem)
        {
            return OnTranslateToViewModel(Service.UpdateWorkItem(commitItem));
        }
    }
}
