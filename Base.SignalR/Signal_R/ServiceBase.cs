using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.SignalR.Signal_R
{
    public abstract class ServiceBase
    {
        protected MyHub Hub { get; set; }

        public ServiceBase(MyHub hub)
        {
            this.Hub = hub;
        }
    }
}
