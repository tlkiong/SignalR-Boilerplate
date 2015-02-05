using SignalR.BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.Client.HubLog
{
    public static class HubLogClient
    {
        public static Task Subscribe(this SignalRClient client, string groupName)
        {
            return client.InvokeService<string>(BEConstant.HubLog.SERVICE_CODE, BEConstant.HubLog.LOG_METHOD, groupName, BEConstant.HubLog.HUB_LOG);
        }
    }
}
