using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TechnologyStore.Startup))]
namespace TechnologyStore
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
