using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OpenBox.Website.Startup))]
namespace OpenBox.Website
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
