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
        public CoWorker AddCoWorker(CoWorker coWorker)
        {
            CoWorker retVal = null;
            using (var db = new CoWorkerDbContext())
            {
                //validate if record exists.
                if (db.CoWorkers.Any(c => c.Name == coWorker.Name))
                {
                    throw new FaultException(string.Format("CoWorker with Name of {0} already exists.", coWorker.Name));
                }

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
                        throw new FaultException("Coworker was not saved.");
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
                    //notes: called eager loading.
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


        public WorkItem AddWorkItem(WorkItem workItem)
        {
            WorkItem retVal = new WorkItem();
            using (var db = new CoWorkerDbContext())
            {
                try
                {
                    db.WorkItems.Add(workItem);
                    db.SaveChanges();

                    long id = workItem.WorkItemId;

                    if (id > 0)
                    {
                        var result = db.WorkItems.Find(new object[] { id, workItem.Title });
                        retVal = result as WorkItem;
                    }
                    else
                    {
                        throw new FaultException("WorkItem was not saved.");
                    }
                }
                catch (Exception e)
                {
                }
            }

            return retVal;
        }

        public WorkItem UpdateWorkItem(WorkItem workItem)
        {
            WorkItem retVal = new WorkItem();
            using (var db = new CoWorkerDbContext())
            {
                try
                {
                    db.WorkItems.Attach(workItem);
                    var workitemEntry = db.Entry(workItem);
                    workitemEntry.State = System.Data.Entity.EntityState.Modified;
                    
                    //todo: study if there is a better way to update child tables.
                    var feedBacks = db.Feedbacks;
                    
                    var strengthToUpdate = feedBacks.FirstOrDefault(f => f.FeedbackId == workItem.Strength.FeedbackId);
                    strengthToUpdate.Comment = workItem.Strength.Comment;
                    db.Entry(strengthToUpdate).State = System.Data.Entity.EntityState.Modified;
                    
                    var areaImprovementToUpdate = feedBacks.FirstOrDefault(f => f.FeedbackId == workItem.AreaForImprovement.FeedbackId);
                    areaImprovementToUpdate.Comment = workItem.AreaForImprovement.Comment;
                    db.Entry(areaImprovementToUpdate).State = System.Data.Entity.EntityState.Modified;

                    db.SaveChanges();

                    long id = workItem.WorkItemId;

                    if (id > 0)
                    {
                        var result = db.WorkItems.Find(new object[] { id, workItem.Title });
                        retVal = result as WorkItem;
                    }
                    else
                    {
                        throw new FaultException("WorkItem was not saved.");
                    }
                }
                catch (Exception e)
                {
                    throw new FaultException("WorkItem was not saved.");
                }
            }

            return retVal;
        }

        public WorkItem GetWorkItem(long workItemId, string title)
        {
            WorkItem retVal = null;
            using (var db = new CoWorkerDbContext())
            {
                try
                {
                    var result = db.WorkItems.Find(new object[] { workItemId, title });
                    retVal = result as WorkItem;
                }
                catch (Exception e)
                {
                }
            }

            return retVal;
        }
    }

}
