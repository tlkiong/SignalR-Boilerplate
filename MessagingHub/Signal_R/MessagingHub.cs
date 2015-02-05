using Base.SignalR.Signal_R;
using SignalR.BE;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Web;

namespace MessagingHub.Signal_R
{
    public class MessagingHub : MyHub
    {
        public void SendMessage(string message)
        {
            Clients.All.broadcast(message);
        }

        public void RunMethod(string service, string action, object parameter, string queryString = null)
        {
            LogStatus(BEConstant.HubLog.HUB_LOG, string.Format(LogMessage.RunMethodMessage, queryString, Context.ConnectionId, service, action));
            try
            {
                string nameSpace = "SignalR";
                var typeOfService = AppDomain.CurrentDomain.GetAssemblies()
                    .Where(a => a.FullName.StartsWith(nameSpace))//To optimize the filtering process
                    .Select(a => a.ExportedTypes)
                    .SelectMany(t => t)
                    .FirstOrDefault(t => t.IsSubclassOf(typeof(ServiceBase)) &&
                        t.IsDefined(typeof(MySignalRServiceAttribute), false) &&
                        TypeDescriptor.GetAttributes(t).OfType<MySignalRServiceAttribute>().First().ServiceCode == service);

                if (typeOfService != null)
                {
                    MethodInfo methodInfo = typeOfService.GetMethods()
                                            .Where(a => a.ReturnParameter.Member.DeclaringType.FullName.StartsWith(nameSpace))
                                            .Select(a => a)
                                            .FirstOrDefault(a => a.ReturnParameter.Member.CustomAttributes
                                                .Any(b => b.NamedArguments
                                                    .Any(c => c.TypedValue.Value.ToString() == action)));

                    if (methodInfo != null)
                    {
                        object result = null;
                        ParameterInfo[] parameters = methodInfo.GetParameters();
                        object classInstance = Activator.CreateInstance(typeOfService, this);
                        if (parameters.Length == 0)
                        {
                            result = methodInfo.Invoke(classInstance, null);
                        }
                        else
                        {
                            result = methodInfo.Invoke(classInstance, new object[] { parameter });
                        }
                    }
                }
                else
                {
                    throw new NullReferenceException("typeOfService");
                }
            }
            catch (Exception ex)
            {
                LogStatus(BEConstant.HubLog.HUB_LOG, string.Format(LogMessage.ExceptionMessage, ex.Message, (ex.InnerException != null) ? ex.InnerException.Message : "null", "RunMethod"));
                //HandleException(ex);
            }
        }

        /// <summary>
        /// Handle exception when caught
        /// </summary>
        /// <param name="ex">Exception</param>
        private void HandleException(Exception ex)
        {
            //Find a way to handle exception logging
        }

        #region Hub Event Handler
        /// <summary>
        /// Hub's OnConnected Event
        /// </summary>
        /// <returns></returns>
        public override Task OnConnected()
        {
            try
            {
                var queryString = Context.QueryString[Base.SignalR.Signal_R.Constants.QueryString.PURPOSE];
                LogStatus(BEConstant.HubLog.HUB_LOG, string.Format(LogMessage.ConnectedMessage, queryString ?? "SignalR", Context.ConnectionId));
            }
            catch (Exception ex)
            {
                LogStatus(BEConstant.HubLog.HUB_LOG, string.Format(LogMessage.ExceptionMessage, ex.Message, (ex.InnerException != null) ? ex.InnerException.Message : "null", "OnConnected"));
            }
            return base.OnConnected();
        }

        /// <summary>
        /// Hub's OnDisconnected event
        /// </summary>
        /// <param name="stopCalled"></param>
        /// <returns></returns>
        public override Task OnDisconnected(bool stopCalled)
        {
            try
            {
                if (stopCalled)
                {
                    // We know that Stop() was called on the client,
                    // and the connection shut down gracefully.
                    LogStatus(BEConstant.HubLog.HUB_LOG, string.Format(LogMessage.DisconnectedMessage, "Not known which", Context.ConnectionId));
                }
                else
                {
                    // This server hasn't heard from the client in the last ~35 seconds.
                    // If SignalR is behind a load balancer with scaleout configured, 
                    // the client may still be connected to another SignalR server.
                    LogStatus(BEConstant.HubLog.HUB_LOG, string.Format("<br>{0} client failed to disconnect gracefully", Context.ConnectionId));
                }
            }
            catch (Exception ex)
            {
                LogStatus(BEConstant.HubLog.HUB_LOG, string.Format(LogMessage.ExceptionMessage, ex.Message, (ex.InnerException != null) ? ex.InnerException.Message : "null", "OnDisconnected"));
            }
            return base.OnDisconnected(stopCalled);
        }

        /// <summary>
        /// Hub's OnReconnected Event
        /// </summary>
        /// <returns></returns>
        public override Task OnReconnected()
        {
            try
            {
                LogStatus(BEConstant.HubLog.HUB_LOG, string.Format(LogMessage.ReconnectedMessage, "Not known which", Context.ConnectionId));
            }
            catch (Exception ex)
            {
                LogStatus(BEConstant.HubLog.HUB_LOG, string.Format(LogMessage.ExceptionMessage, ex.Message, (ex.InnerException != null) ? ex.InnerException.Message : "null", "OnReconnected"));
            }
            return base.OnReconnected();
        }
        #endregion Hub Event Handler
    }
}