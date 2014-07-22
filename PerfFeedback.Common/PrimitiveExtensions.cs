using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfFeedback.Common
{
    public static class PrimitiveExtensions
    {
        public static bool IsTrue(this bool? value)
        {
            if (value.HasValue)
            {
                return value.Value;
            }

            return false;
        }
    }
}
