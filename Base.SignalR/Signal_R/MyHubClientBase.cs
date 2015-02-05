using Microsoft.AspNet.SignalR.Client;
using Microsoft.AspNet.SignalR.Client.Http;
using Microsoft.AspNet.SignalR.Client.Transports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.SignalR.Signal_R
{
    public abstract class MyHubClientBase : IDisposable
    {
        public HubConnection HubConnection { get; protected set; }
        public IHubProxy HubProxy { get; protected set; }
        public string ServiceCode { get; protected set; }

        public MyHubClientBase(string url, string purpose = null)
        {
            if (string.IsNullOrEmpty(purpose))
            {
                this.HubConnection = new HubConnection(url);
            }
            else
            {
                this.HubConnection = new HubConnection(url, Constants.QueryString.PURPOSE + "=" + purpose);
            }
        }

        public MyHubClientBase(string url, string hubName, string purpose = null)
        {
            if (string.IsNullOrEmpty(purpose))
            {
                this.HubConnection = new HubConnection(url);
            }
            else
            {
                this.HubConnection = new HubConnection(url, Constants.QueryString.PURPOSE + "=" + purpose);
            }
            this.HubProxy = this.HubConnection.CreateHubProxy(hubName);
        }

        public IHubProxy CreateHubProxy(string hubName)
        {
            this.HubProxy = this.HubConnection.CreateHubProxy(hubName);
            return this.HubProxy;
        }

        /// <summary>
        /// Starts the Microsoft.AspNet.SignalR.Client.Connection
        /// </summary>
        /// <returns>A task that represents when the connection has started</returns>
        public Task Start()
        {
            return this.HubConnection.Start();
        }

        /// <summary>
        /// Starts the Microsoft.AspNet.SignalR.Client.Connection
        /// </summary>
        /// <param name="transport">The transport type to be used</param>
        /// <returns>A task that represents when the connection has started</returns>
        public Task Start(IClientTransport transport)
        {
            return this.HubConnection.Start(transport);
        }

        /// <summary>
        /// Starts the Microsoft.AspNet.SignalR.Client.Connection
        /// </summary>
        /// <param name="transport">The http client</param>
        /// <returns>A task that represents when the connection has started</returns>
        public Task Start(IHttpClient httpClient)
        {
            return this.HubConnection.Start(httpClient);
        }

        public Task InvokeService<T>(string method, T args, string queryString = "SignalR Client") where T : class
        {
            return this.HubProxy.Invoke("RunMethod", this.ServiceCode, method, args, queryString);
        }

        /// <summary>
        /// To Invoke Hub's method
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="service">Service Name</param>
        /// <param name="method">Method's Name</param>
        /// <param name="args">arguements</param>
        /// <returns></returns>
        public Task InvokeService<T>(string service, string method, T args, string queryString = "SignalR Client") where T : class
        {
            return this.HubProxy.Invoke("RunMethod", service, method, args, queryString);
        }

        /// <summary>
        /// Stop the Microsoft.AspNet.SignalR.Client.Connection and sends an abort message to the server
        /// </summary>
        public void Stop()
        {
            this.HubConnection.Stop();
        }

        /// <summary>
        /// Stop the Microsoft.AspNet.SignalR.Client.Connection and sends an abort message to the server
        /// </summary>
        /// <param name="timeout">Timeout before stop connection</param>
        public void Stop(TimeSpan timeout)
        {
            this.HubConnection.Stop(timeout);
        }

        public void Dispose()
        {
            if (this.HubConnection != null)
            {
                this.HubConnection.Stop();
                this.Dispose();
            }
        }
    }
}
