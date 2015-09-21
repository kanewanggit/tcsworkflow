using System.Web.Mvc;
using System.Web.Routing;
using WorkflowActivityLibrary;

namespace WebCoreLibrary
{
    public class GlobalApplication : System.Web.HttpApplication
    {
        protected virtual void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            UnityRegistration.Register();
        }

    }
}
