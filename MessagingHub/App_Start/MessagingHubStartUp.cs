using Microsoft.Owin.Cors;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MessagingHub.App_Start
{
    public class MessagingHubStartUp
    {
        public void Configuration(IAppBuilder app)
        {
            try
            {
                app.UseCors(CorsOptions.AllowAll);
                ////For scaling out on SQL backplane
                //SqlScaleoutConfiguration config = new SqlScaleoutConfiguration(ConfigurationManager.ConnectionStrings["SignalR"].ToString();

                ////Default table count
                //int tableCount = 5;
                //string SignalRDBTableCount = Configurationmanager.AppSettings["SignalRDBTableCount"];

                //int.TryParse(SignalRDBTableCount, out tableCount);

                //config.TableCount = tableCount;
                //GlobalHost.DependencyResolver.UseSqlServer(config);
                app.MapSignalR();
            }
            catch (Exception ex)
            {
                throw ex.GetBaseException();
            }
        }
    }
}