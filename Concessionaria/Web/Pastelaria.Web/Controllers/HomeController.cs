using System.Web.Mvc;

namespace Concessionaria.Web.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Sobre()
        {
            return View();
        }
    }
}