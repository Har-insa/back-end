using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ConnextBackOffice.Startup))]
namespace ConnextBackOffice
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
