using Base.SignalR.Signal_R;
using SignalR.BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.Service.HubLogService
{
    [MySignalRService(ServiceCode = BEConstant.HubLog.SERVICE_CODE)]
    public class HubLogService : ServiceBase
    {
        public HubLogService(MyHub hub)
            : base(hub)
        {
        }

        [MySignalRMethod(MethodCode = BEConstant.HubLog.LOG_METHOD)]
        public void Log(object parameter)
        {
            string groupName = parameter as string;
            try
            {
                Hub.Groups.Add(Hub.Context.ConnectionId, groupName);
                Hub.LogStatus(BEConstant.HubLog.HUB_LOG, string.Format(LogMessage.SubscribeServiceMessage, groupName, Hub.Context.ConnectionId, groupName));
            }
            catch
            {
                throw;
            }
        }
    }
}
