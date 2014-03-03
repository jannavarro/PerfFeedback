using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfFeedback.Client.Interfaces
{
    public interface IItemView
    {
        void FailedCommit(string error);
        void SuccessCommit(object response);
    }
}
