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
        CoWorker AddCoWorker(CoWorker coWorker);

        [OperationContract]
        CoWorker UpdateCoWorker(CoWorker coWorker);

        [OperationContract]
        CoWorker GetCoWorker(long coWorkerId, string name);

        [OperationContract]
        WorkItem AddWorkItem(WorkItem workItem);

        [OperationContract]
        WorkItem UpdateWorkItem(WorkItem workItem);

        [OperationContract]
        WorkItem GetWorkItem(long workItemId, string title);

        [OperationContract]
        List<CoWorker> GetAllCoWorkers();
    }
}
