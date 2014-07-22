using System;
using System.Collections.Generic;
using System.Linq;
using PerfFeedback.BusinessService.Contract;
using PerfFeedback.Client.PerfLocal;
using PerfFeedback.Framework;
using VM = PerfFeedback.Client.ViewModels;
namespace PerfFeedback.Client.Models{    public class CoWorkerModel : Model<CoWorker, VM.CoWorker>    {
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

        public CoWorkerModel()
        {

        }

        protected override VM.CoWorker OnCommit(CoWorker commitItem)
        {
            return OnTranslateToViewModel(Service.AddCoWorker(commitItem));
        }

        protected override List<VM.CoWorker> OnGetAll()
        {
            var coWorkers = Service.GetAllCoWorkers().ToList();
            List<VM.CoWorker> retVal = new List<VM.CoWorker>();
            foreach (var coWorker in coWorkers)
            {
                retVal.Add(OnTranslateToViewModel(coWorker));
            }

            return retVal;
        }

        protected override void OnPublish(VM.CoWorker item)
        {
            SubscribeResponse response = new SubscribeResponse() { ExpectedResponse = item, StatusResult = Framework.Result.Success };
            TempEventBus.Publish("CommitCoWorker", response);
        }

        protected override VM.CoWorker OnGet(long id, List<object> obj)
        {
            //var coWorker = Service.GetCoWorker(id);
            //return OnTranslateToViewModel(coWorker);
            return null;
        }

        protected override VM.CoWorker OnUpdate(CoWorker commitItem)
        {
            throw new NotImplementedException();
            //return Service.UpdateCoWorker(commitItem);
        }
    }}
