using PerfFeedback.BusinessService.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace PerfFeedback.WcfBusinessService
{
    [ServiceContract]
    public interface ICoWorkerService
    {
        [OperationContract]
        CoWorker CommitCoWorker(CoWorker item);
    }
}
