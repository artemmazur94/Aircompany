using System.Web.ModelBinding;
using Aircompany.Web;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Startup))]
namespace Aircompany.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

            //ModelValidatorProviders.Providers.Clear();
            //ModelValidatorProviders.Providers.Add(new AttributeValidatorProvider());
        }
    }
}
