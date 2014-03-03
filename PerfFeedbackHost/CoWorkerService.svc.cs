using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using PerfFeedback.BusinessService.Contract;

namespace PerfFeedbackHost
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class CoWorkerService : ICoWorkerService
    {
        public CoWorker AddCoWorker(CoWorker coWorker)
        {
            CoWorker retVal = null;
            //using (var db = new CoWorkerDbContext())
            //{
            //    try
            //    {
            //        db.CoWorkers.Add(coWorker);
            //        db.SaveChanges();

            //        long id = coWorker.CoWorkerId;

            //        if (id > 0)
            //        {
            //            var result = db.CoWorkers.Find(new object[] { id, coWorker.Name });
            //            retVal = result as CoWorker;
            //        }
            //        else
            //        {
            //            throw new Exception("Coworker was not saved.");
            //        }
            //    }
            //    catch (Exception e)
            //    {
            //    }
            //}

            return coWorker;
        }


        public CoWorker UpdateCoWorker(CoWorker coWorker)
        {
            throw new NotImplementedException();
        }

        public CoWorker GetCoWorker(long coWorkerId, string name)
        {
            throw new NotImplementedException();
        }
    }
}
