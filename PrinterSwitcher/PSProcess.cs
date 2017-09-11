using System;
using System.Collections.Generic;
using System.Text;

namespace PrinterSwitcher
{
    [Serializable]
    public class PSProcess
    {

        private string mProcessName = string.Empty;

        private bool mISMDIContainer = false;

        private string mMappedPrinter = string.Empty;
        
        public string ProcessName
        {
            get
            {
                return mProcessName;
            }
        }

        public bool ISMDIContainer
        {
            get
            {
                return mISMDIContainer;
            }
        }

        public string MappedPrinter
        {
            get
            {
                return mMappedPrinter;
            }
            set
            {
                mMappedPrinter = value;
            }
        }
        
        /// <summary>
        /// For deserialization only
        /// </summary>
        public PSProcess()
        {
        }

        public PSProcess(string processName, bool mdiContainer)
        {
            mProcessName = processName;
            mISMDIContainer = mdiContainer;
        }        
    }
}
