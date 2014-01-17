using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfFeedback.Client
{
    public class ListCoWorker : ListViewModel<CoWorkerViewModel>
    {
        int _id = 0;

        public void Add(string name)
        {
            this.Add(new CoWorkerViewModel() { ID = _id++, Name = name });
        }

        public ObservableCollection<CoWorkerViewModel> Items
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
            this.Add(new CoWorkerViewModel() { ID = _id++, Name = "Jan" });
            this.Add(new CoWorkerViewModel() { ID = _id++, Name = "Lloyd" });
        }
    }
}
