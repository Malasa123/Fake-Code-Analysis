using System.Web.Mvc;

namespace Fake_Code_Analysis_Implementation_5_03.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
    }
}
