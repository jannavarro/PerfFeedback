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

        public CoWorker AddCoWorker(CoWorker coWorker)
        {
            CoWorker retVal = null;
            using (var db = new CoWorkerDbContext())
            {
                try
                {
                    db.CoWorkers.Add(coWorker);
                    db.SaveChanges();

                    long id = coWorker.CoWorkerId;

                    if (id > 0)
                    {
                        var result = db.CoWorkers.Find(new object[] { id });
                        retVal = result as CoWorker;
                    }
                    else
                    {
                        throw new Exception("Coworker was not saved.");
                    }
                }
                catch (Exception e)
                {
                }
            }

            return retVal;
        }


        public CoWorker UpdateCoWorker(CoWorker coWorker)
        {
            throw new NotImplementedException();
        }

        public CoWorker GetCoWorker(long coWorkerId, string name)
        {
            throw new NotImplementedException();
        }

        public List<CoWorker> GetAllCoWorkers()
        {
            List<CoWorker> retVal = new List<CoWorker>();
            using (var db = new CoWorkerDbContext())
            {
                try
                {
                    var coWorkers = db.CoWorkers
                                        .Include("WorkItems")
                                        .ToList();
                    List<Feedback> feedbacks = db.Feedbacks.ToList();
                    foreach (var coWorker in coWorkers)
                    {
                        foreach (var wi in coWorker.WorkItems)
                        {
                            if(wi.AreaForImprovement_FeedbackId.HasValue)
                            {
                                wi.AreaForImprovement = feedbacks.Find(fb => fb.FeedbackId == wi.AreaForImprovement_FeedbackId.Value) as AreaForImprovement;
                            }
                            if (wi.Strength_FeedbackId.HasValue)
                            {
                                wi.Strength = feedbacks.Find(fb => fb.FeedbackId == wi.Strength_FeedbackId.Value) as Strength;
                            }
                        }
                        
                        retVal.Add(coWorker);
                    }
                }
                catch (Exception e)
                {
                }
            }

            return retVal;
        }
    }

}
