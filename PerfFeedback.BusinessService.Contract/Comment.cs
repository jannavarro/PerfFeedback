using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PerfFeedback.BusinessService.Contract
{
    [DataContract]
    public class Comment : MarshalByRefObject
    {
        private string _feedback = string.Empty;

        public string Feedback
        {
            get
            {
                return _feedback;
            }
            set
            {
                _feedback = value;
            }
        }
    }
}
