using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using PerfFeedback.Client.Models;
using PerfFeedback.Framework;

namespace PerfFeedback.Client.ViewModels{
    [DataContract(Namespace = "http://perf.com/perf")]
    public class CoWorker : ItemViewModel    {
        public CoWorker()
        {
            OperationState = ViewModels.OperationState.Add;
        }

        public CoWorker(CoWorker copy)
        {
            this.Id = copy.Id;
            this.WorkItemName = copy.WorkItemName;
            this.Name = copy.Name;
            if (copy.CurrentWorkItem != null)
            {
                this.CurrentWorkItem = new WorkItem(copy.CurrentWorkItem);
            }

            if (WorkItems == null)
            {
                WorkItems = new ListWorkItem();
                WorkItems.SelectedItemChanged += WorkItems_SelectedItemChanged;
            }
            WorkItems.Clear();
            foreach (WorkItem item in copy.WorkItems)
            {
                WorkItems.Add(new WorkItem(item));
            }
        }

        private void WorkItems_SelectedItemChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            CurrentWorkItem = WorkItems.SelectedItem;
        }        private CoWorkerModel _model;        public CoWorkerModel Model        {          get           {              if(_model == null)              {                  _model = new CoWorkerModel();              }              return _model;           }          set { _model = value; }        }        [DataMember]
        public long Id { get; set; }

        [DataMember]
        public string WorkItemName { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public ListWorkItem WorkItems { get; set; }

        public WorkItem CurrentWorkItem { get; set; }

        protected override void OnInitialize()
        {
            if (OperationState != ViewModels.OperationState.Edit)
            {
                WorkItemName = string.Empty;
                Name = string.Empty;
                CurrentWorkItem = new WorkItem();
                WorkItems = new ListWorkItem { CurrentWorkItem };
                //Clear any previous event handlers.
                WorkItems.SelectedItemChanged -= WorkItems_SelectedItemChanged;
                WorkItems.SelectedItemChanged += WorkItems_SelectedItemChanged;
            }
        }

        protected override void OnInitialize(long id)
        {
            Model.Get(id);
        }        
        protected override void OnCommit()        {            Model.Commit(this);        }

        protected override void OnSubscribe()
        {
            TempEventBus.Subscribe("CommitCoWorker", this);
        }

        protected override void OnHandleNotification(SubscribeResponse response)
        {
            if (response.Result == Result.Success)
            {
                ItemView.SuccessCommit(null);
            }
            else
            {
                ItemView.FailedCommit(response.ErrorMessage);
            }
        }
    }}
