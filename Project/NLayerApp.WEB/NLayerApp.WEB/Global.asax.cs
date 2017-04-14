//using NLayerApp.BL.Filters;
using NLayerApp.DI;
using NLayerApp.WEB.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace NLayerApp.WEB
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
           // FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
           // GlobalFilters.Filters.Add(new CultureAttribute());
           // RegisterGlobalFilters(GlobalFilters.Filters);
       
        }
    }
}
