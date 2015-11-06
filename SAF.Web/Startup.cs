using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SAF.Web.Startup))]
namespace SAF.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
