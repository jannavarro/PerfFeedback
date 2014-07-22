using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PerfFeedback.Client.ApplicationSettings
{
    public class ApplicationSettings
    {
        private static ApplicationSettings _instance = null;
        private static object _syncRoot = null;

        public static ApplicationSettings Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ApplicationSettings();
                    _instance.Initialize();
                }
                return _instance; 
            }
        }

        private void Initialize()
        {
            lock (_syncRoot)
            {
                throw new NotImplementedException();
            }
        }
 
    }
}
