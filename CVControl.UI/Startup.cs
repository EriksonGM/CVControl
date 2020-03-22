using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CVControl.UI.Startup))]
namespace CVControl.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
