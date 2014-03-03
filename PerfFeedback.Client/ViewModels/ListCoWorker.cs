using System.Collections.Generic;
using System.Collections.ObjectModel;
using PerfFeedback.Client.Models;

namespace PerfFeedback.Client.ViewModels
{
    public class ListCoWorker : ListViewModel<CoWorker, CoWorkerModel>
    {
        int _id = 0;
        public void Add(string name)
        {
            this.Add(new CoWorker() { Id = _id++, Name = name });
        }

        public ObservableCollection<CoWorker> Items
        {
            get
            {
                return this;
            }
            set
            {
                //this.PropertyChanged(this, null);
                //if (handler != null)
                //{
                //    handler(this, null);
                //}
            }
        }

        public ListCoWorker()
        {
            //ListWorkItem workItems = new ListWorkItem();
            //workItems.Add(new WorkItem() { AreaForImprovement = new AreaForImprovement() { Comment = "Pokemon" }, Strength = new Strength() { Comment = "Gotta catch em all" } });
            //this.Add(new CoWorker() { Id = _id++, Name = "Jan", WorkItems = workItems });
            //this.Add(new CoWorker() { Id = _id++, Name = "Lloyd" });
        }

        public ListCoWorker(ListCoWorker copy)
        {
            foreach (CoWorker item in copy.Items)
            {
                this.Add(new CoWorker(item));
            }
        }

        protected override void OnInitializeItems()
        {
            var items = Model.GetAll();
            if (items != null)
            {
                foreach (var item in items)
	            {
                    this.Add(item);
	            }
            }
        }
    }
}
