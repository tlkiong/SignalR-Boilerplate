using Microsoft.AspNet.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.SignalR.SignalR
{
    public static class SignalRExtension
    {
        public static Task InvokeServiceAction<T>(this IHubProxy proxy, string service, string method, T args) where T : class
        {
            return proxy.Invoke("RunMethod", service, method, args);
        }
    }
}
