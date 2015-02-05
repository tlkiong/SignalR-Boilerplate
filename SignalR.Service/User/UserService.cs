using Base.SignalR.Signal_R;
using Newtonsoft.Json;
using SignalR.BE;
using SignalR.BE.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.Service.User
{
    [MySignalRService(ServiceCode = BEConstant.User.SERVICE_CODE)]
    public class UserService : ServiceBase
    {
        public UserService(MyHub hub)
            : base(hub)
        {
        }

        /// <summary>
        /// To register connected users
        /// </summary>
        /// <param name="objUserData">User Data</param>
        [MySignalRMethod(MethodCode = BEConstant.User.LOGIN_METHOD)]
        public void Login(object objUserData)
        {
            UserData userData = JsonConvert.DeserializeObject<UserData>(objUserData.ToString());

            if ((userData == null) || (string.IsNullOrEmpty(userData.username)) || (userData.userID == 0) || string.IsNullOrEmpty(userData.password))
            {
                this.Hub.LogStatus(BEConstant.HubLog.HUB_LOG, string.Format("userdata is null or empty"));
            }
            try
            {
                //Add prefix of "T" to the group name of Loginname
                //Hub.Groups.Add(Hub.Context.ConnectionId, BEConstant.User. + userData.loginName);
                this.Hub.LogStatus(BEConstant.HubLog.HUB_LOG, string.Format("<br>Username: {0} logged in", userData.username));
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// To register connected users
        /// </summary>
        /// <param name="objUserData">User Data</param>
        [MySignalRMethod(MethodCode = BEConstant.User.LOGOUT_METHOD)]
        public void Logout(object objUserData)
        {
            UserData userData = JsonConvert.DeserializeObject<UserData>(objUserData.ToString());

            if ((userData == null) || (string.IsNullOrEmpty(userData.username)) || (userData.userID == 0) || string.IsNullOrEmpty(userData.password))
            {
                this.Hub.LogStatus(BEConstant.HubLog.HUB_LOG, string.Format("userdata is null or empty"));
            }
            try
            {
                //Add prefix of "T" to the group name of Loginname
                //Hub.Groups.Add(Hub.Context.ConnectionId, BEConstant.User. + userData.loginName);
                this.Hub.LogStatus(BEConstant.HubLog.HUB_LOG, string.Format("<br>Username: {0} logged out", userData.username));
            }
            catch
            {
                throw;
            }
        }
    }
}
