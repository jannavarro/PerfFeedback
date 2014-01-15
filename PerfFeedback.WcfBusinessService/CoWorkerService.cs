using PerfFeedback.BusinessService.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace PerfFeedback.WcfBusinessService
{
    public class CoWorkerService : ICoWorkerService
    {
        //private IDataService _dataService;
        //private IDataService DataService
        //{
        //    get
        //    {
        //        if (_dataService == null)
        //        {
        //            _dataService = ServiceLocator.Find<IDataService>();
        //        }
        //    }
        //}

        public CoWorker CommitCoWorker(CoWorker commitItem)
        {
            using (var db = new FeedbackContext())
            {
                db.CoWorker.Add(commitItem);

                foreach (Strength item in commitItem.Strengths)
                {
                    db.Strengths.Add(item);                    
                }

                foreach (AreaForImprovement item in commitItem.AreasForImprovement)
                {
                    db.AreasForImprovement.Add(item);
                }

                db.SaveChanges();

                // Display all Blogs from the database
                var query = from s in db.Strengths
                            orderby s.Feedback
                            select s;

                foreach (var item in query)
                {
                    Console.WriteLine(item.Feedback);
                }

                //return db.CoWorker;
                return new CoWorker();
            }
        }
    }

}
