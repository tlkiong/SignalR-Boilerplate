using Base.SignalR.Signal_R;
using SignalR.BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.Service.Common
{
    [MySignalRService(ServiceCode = BEConstant.Common.SERVICE_CODE)]
    public class CommonService : ServiceBase
    {
        public CommonService(MyHub hub)
            : base(hub)
        {
        }
    }
}
