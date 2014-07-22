
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using PerfFeedback.Client.Models;
using PerfFeedback.Framework;

namespace PerfFeedback.Client.ViewModels
{
    public class ListWorkItem : ListViewModel<WorkItem, CoWorkerModel>
    {
        public ObservableCollection<WorkItem> Items
        {
            get
            {
                return this;
            }
            set
            {
            }
        }

        public ListWorkItem()
        {
        }

        public ListWorkItem(ListWorkItem copy)
        {
            foreach (var item in copy)
            {
                this.Add(new WorkItem(item));
            }
        }

        protected override void OnInitializeItems()
        {
            //throw new NotImplementedException();
        }

        protected override void OnSubscribe()
        {
            TempEventBus.Subscribe("CommitWorkItem", this);
        }

        protected override void OnHandleNotification(SubscribeResponse response)
        {
            if (response.StatusResult == Result.Success)
            {
                var workItem = response.ExpectedResponse as WorkItem;
                var toUpdate = this.FirstOrDefault(w => w.WorkItemId == workItem.WorkItemId);
                
                //add or update
                if (toUpdate == null)
                {
                    this.Add(workItem);
                }
                else
                {
                    toUpdate = workItem;
                }
            }
            else
            {
                
            }
        }
    }
}
