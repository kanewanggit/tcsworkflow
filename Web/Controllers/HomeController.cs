using System.Web.Mvc;
using Base.Dto;
using Base.ManagerInterface;
using Microsoft.Practices.ServiceLocation;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult InitFlow(EmailDto dto)
        {
            if (ModelState.IsValid)
            {
                var manager = ServiceLocator.Current.GetInstance<IEmailFlowManager>();
                var id = manager.InitEmailFlow(dto);

            }
            return View("Index");
        }
    }

}
