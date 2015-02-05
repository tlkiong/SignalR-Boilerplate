using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.SignalR.Signal_R
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public sealed class MySignalRServiceAttribute : Attribute
    {
        public string ServiceCode { get; set; }
    }

    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public sealed class MySignalRMethodAttribute : Attribute
    {
        public string MethodCode { get; set; }
    }
}
