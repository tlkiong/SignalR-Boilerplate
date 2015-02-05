using SignalR.BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.Client
{
    public class SignalRClientHelper : Base.SignalR.Common.SingletonBase<SignalRClientHelper>
    {
        private SignalRClient client;
        public SignalRClient Client { get { return client; } }

        private SignalRClientHelper()
        {
        }

        public void Initialize(string url, string purpose = null, bool isAutoReconnect = false)
        {
            this.Initialize(url, BEConstant.HUB_NAME, purpose, isAutoReconnect);
        }

        public void Initialize(string url, string hubName = BEConstant.HUB_NAME, string purpose = null, bool isAutoReconnect = false)
        {
            client = new SignalRClient(url, hubName, purpose, isAutoReconnect);
        }

        public void LogException(Exception e)
        {
            //Exception logging into database
        }
    }
}
