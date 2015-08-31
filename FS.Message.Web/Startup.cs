using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FS.Message.Web.Startup))]
namespace FS.Message.Web
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
