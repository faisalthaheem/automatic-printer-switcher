using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace PrinterSwitcher
{
    [Serializable()]
    public class PSProcessCollection : Dictionary<string, PSProcess>
    {
        public string mSysDefPrinter = string.Empty;

        public PSProcessCollection() : base()
        {
        }

        public PSProcessCollection(SerializationInfo info, StreamingContext context)
            : base(info,context)
        {
            this.mSysDefPrinter = (string)info.GetValue("mSysDefPrinter", typeof(string));
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            base.GetObjectData(info, ctxt);
            info.AddValue("mSysDefPrinter", mSysDefPrinter);
        }
    }
}
