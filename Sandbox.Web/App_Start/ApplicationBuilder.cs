using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Sandbox.Web2
{
    public class ApplicationBuilder
    {
        protected readonly HttpConfiguration HttpConfig;
        protected readonly GlobalFilterCollection Filters;
        protected readonly RouteCollection Routes;
        protected readonly BundleCollection Bundles;
        protected readonly AutofacConfig AutofacConfig;

        public ApplicationBuilder()
        {
            HttpConfig = GlobalConfiguration.Configuration;
            Filters = GlobalFilters.Filters;
            Routes = RouteTable.Routes;
            Bundles = BundleTable.Bundles;
            AutofacConfig = new AutofacConfig();
        }

        public void BootstrapMvc()
        {
            AutofacConfig.Configure(HttpConfig);
            AreaRegistration.RegisterAllAreas();
            WebApiConfig.Register(HttpConfig);
            FilterConfig.RegisterGlobalFilters(Filters);
            RouteConfig.RegisterRoutes(Routes);
            BundleConfig.RegisterBundles(Bundles);
            AuthConfig.RegisterAuth();
        }
    }
}