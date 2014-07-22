using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using PerfFeedback.Client.Models;
using PerfFeedback.Framework;

namespace PerfFeedback.Client.ViewModels{
    [DataContract(Namespace = "http://perf.com/perf")]
    public class CoWorker : ItemViewModel<CoWorkerModel>    {
        private ListWorkItem _listWorkItems = new ListWorkItem();

        public CoWorker()
        {
        }

        public CoWorker(CoWorker copy)
        {
            this.CoWorkerId = copy.CoWorkerId;
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
        }        [DataMember]
        public long CoWorkerId { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public ListWorkItem WorkItems 
        {
            get
            {
                return _listWorkItems;
            }
            set
            {
                _listWorkItems = value;
                OnPropertyChanged("WorkItems");
            }
        }

        public WorkItem CurrentWorkItem { get; set; }

        protected override void OnInitialize()
        {
            if (OperationState != ViewModels.OperationState.Edit)
            {
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
            throw new NotImplementedException();
        }        
        protected override void OnCommit()        {
            if (OperationState != ViewModels.OperationState.Edit)
            {
                Model.Commit(this);
            }
            else
            {
                Model.Update(this);
            }        }

        protected override void OnSubscribe()
        {
            TempEventBus.Subscribe("CommitCoWorker", this);
        }

        protected override void OnHandleNotification(SubscribeResponse response)
        {
            if (response.StatusResult == Result.Success)
            {
                ItemView.SuccessCommit(true);
            }
            else
            {
                ItemView.FailedCommit(response.ErrorMessage);
            }
        }
    }}
