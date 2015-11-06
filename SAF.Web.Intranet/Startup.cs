using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SAF.Web.Intranet.Startup))]
namespace SAF.Web.Intranet
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
