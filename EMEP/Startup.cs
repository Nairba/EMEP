using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EMEP.Startup))]
namespace EMEP
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
