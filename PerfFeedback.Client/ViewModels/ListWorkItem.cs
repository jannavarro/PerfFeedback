
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using PerfFeedback.Client.Models;

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
    }
}
