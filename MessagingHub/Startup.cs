using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MessagingHub.Startup))]
namespace MessagingHub
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
