using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BE
{
    public class BEConstant
    {
        public const string HUB_NAME = "MyHub";

        //Strings specifically used by HubLog function
        public class HubLog
        {
            public const string SERVICE_CODE = "HubLog";
            public const string HUB_LOG = "HubLog";
            public const string LOG_METHOD = "LogMethod";
            public const string QUERYSTRING = "Hub Log";
        }

        //Enter all commonly used strings here
        public class Common
        {
            public const string SERVICE_CODE = "Common";

            public const string PREFIX_SERVICE = "Service";
        }

        //Strings specifically for User functions
        public class User
        {
            //MUST have SERVICE_CODE - its how we identify which dll to access
            public const string SERVICE_CODE = "User";

            //Methods must be the same string as the declaration of their methods
            public const string LOGIN_METHOD = "UserLogin";
            public const string LOGOUT_METHOD = "Logout";

            public const string USER_LOG = "UserLog";
        }
    }
}
