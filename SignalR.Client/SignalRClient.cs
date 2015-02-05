using Base.SignalR.SignalR;
using Microsoft.AspNet.SignalR.Client;
using Microsoft.AspNet.SignalR.Client.Http;
using Microsoft.AspNet.SignalR.Client.Transports;
using SignalR.BE;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.Client
{
    public class SignalRClient : MyHubClientBase
    {
        public delegate void ReconnectedEventHandler(object sender, CancelEventArgs e);
        public event ReconnectedEventHandler Reconnected;

        public bool IsAutoReconnect {get; private set;}
        public TimeSpan ReconnectTimeout { get; set; }
        public bool isStopOnPurpose;

        public SignalRClient(string url, string purpose=null, bool isAutoReconnect = false)
            :this(url, BEConstant.HUB_NAME, purpose, isAutoReconnect)
        {
        }

        public SignalRClient(string url, string hubName, string purpose = null, bool isAutoReconnect = false)
            : base(url, hubName, purpose)
        {
            this.IsAutoReconnect = isAutoReconnect;
            this.ReconnectTimeout = new TimeSpan(0, 0, 30);
            if(this.IsAutoReconnect)
            {
                this.HubConnection.Closed += HubConnection_Closed;
            }
        }

        private void HubConnection_Closed()
        {
            if(this.IsAutoReconnect)
            {
                //Retry if it is not stopped on purpose
                if(!this.isStopOnPurpose)
                {
                    System.Threading.Thread.Sleep(this.ReconnectTimeout);
                    this
                        .Start()
                        .ContinueWith(task =>
                        {
                            if (!task.IsFaulted)
                            {
                                this.RaiseReconnected(this);
                            }
                        });
                }
            }
        }

        private bool RaiseReconnected(object source)
        {
            var handler = this.Reconnected;
            if(handler != null)
            {
                var e = new CancelEventArgs();
                handler(source ?? this, e);
                return !(e.Cancel);
            }
            return true;
        }

        public new Task InvokeService<T>(string method, T args, string queryString = null) where T : class
        {
            if(this.HubConnection.State== ConnectionState.Connected)
            {
                return base.InvokeService<T>(method, args, queryString);
            }
            else
            {
                throw new HubException(LogMessage.ExceptionHubConnectionFail);
            }
        }

        public new Task InvokeService<T>(string service, string method, T args, string queryString = null) where T : class
        {
            if (this.HubConnection.State == ConnectionState.Connected)
            {
                return base.InvokeService<T>(service, method, args, queryString);
            }
            else
            {
                throw new HubException(LogMessage.ExceptionHubConnectionFail);
            }
        }

        public new Task Start()
        {
            this.isStopOnPurpose = false;
            return base.Start();
        }

        public new Task Start(IClientTransport transport)
        {
            this.isStopOnPurpose = false;
            return base.Start(transport);
        }

        public new Task Start(IHttpClient httpClient)
        {
            this.isStopOnPurpose = false;
            return base.Start(httpClient);
        }
        
        public new void Stop()
        {
            this.isStopOnPurpose = true;
            base.Stop();
        }

        public new void Stop(TimeSpan timeout)
        {
            this.isStopOnPurpose = true;
            base.Stop();
        }
    }
}
