using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using PerfFeedback.Client.Models;
using PerfFeedback.Framework;

namespace PerfFeedback.Client.ViewModels
{
    [DataContract(Namespace = "http://perf.com/perf")]
    public class WorkItem : ItemViewModel<WorkItemModel>
    {
        /// <remarks>
        /// Do not set as DataMember. This for UI display purposes only; The real property is in CoWorker class.
        /// </remarks>
        public string CoWorkerName { get; set; }

        [DataMember]
        public long WorkItemId { get; set; }
        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public long CoWorkerId { get; set; }
        [DataMember]
        public Strength Strength { get; set; }

        [DataMember]
        public AreaForImprovement AreaForImprovement { get; set; }

        public WorkItem()
        {
        }

        public WorkItem(WorkItem copy)
        {
            CoWorkerId = copy.CoWorkerId;
            WorkItemId = copy.WorkItemId;
            Title = copy.Title;
            Strength = new Strength(copy.Strength);
            AreaForImprovement = new AreaForImprovement(copy.AreaForImprovement);
        }

        protected override void OnHandleNotification(Framework.SubscribeResponse response)
        {
            if (response.StatusResult == Result.Success)
            {
                ItemView.SuccessCommit(true);
            }
            else
            {
                ItemView.FailedCommit(response.ErrorMessage);
            }
        }

        protected override void OnSubscribe()
        {
            TempEventBus.Subscribe("CommitWorkItem", this);
        }

        protected override void OnInitialize()
        {
            if (OperationState != ViewModels.OperationState.Edit)
            {
                Title = string.Empty;
                Strength = new Strength();
                AreaForImprovement = new AreaForImprovement();
            }
        }

        protected override void OnInitialize(long id)
        {
            throw new NotImplementedException();
        }

        protected override void OnCommit()
        {
            if (OperationState != ViewModels.OperationState.Edit)
            {
                Model.Commit(this);
            }
            else
            {
                Model.Update(this);
            }
        }
    }
}
