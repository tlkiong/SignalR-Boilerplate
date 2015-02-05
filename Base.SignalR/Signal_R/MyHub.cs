using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.SignalR.Signal_R
{
    public class MyHub : Hub
    {
        public void LogStatus(string groupName, string log)
        {
            try
            {
                Clients.Group(groupName).OnStatusLogged(DateTime.Now.ToString("yyyy-MMM-dd HH:mm:ss"), log);
            }
            catch
            {
                throw;
            }
        }
    }
}
