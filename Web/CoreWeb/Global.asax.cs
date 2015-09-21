using System.Web.Optimization;
using WebCoreLibrary;

namespace CoreWeb
{
    public class MvcApplication : GlobalApplication
    {
        protected override void Application_Start()
        {
            base.Application_Start();

            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
