using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Geovanni.Biblioteca.MVC.Startup))]
namespace Geovanni.Biblioteca.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
