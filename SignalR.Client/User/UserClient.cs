using SignalR.BE;
using SignalR.BE.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.Client.User
{
    public static class UserClient
    {
        //Standard is the name of this method equals the name of the original method in Signalr.Service
        public static Task Login(this SignalRClient client, UserData userData, string whoAreYou)
        {
            //(Service, Method, Arguments to be used, Query String)
            return client.InvokeService<UserData>(BEConstant.User.SERVICE_CODE, BEConstant.User.LOGIN_METHOD, userData, whoAreYou);
        }

        public static Task Logout(this SignalRClient client, UserData userData, string whoAreYou)
        {
            return client.InvokeService<UserData>(BEConstant.User.SERVICE_CODE, BEConstant.User.LOGOUT_METHOD, userData, whoAreYou);
        }
    }
}
