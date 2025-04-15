using Concessionaria.Web.Infra;
using System.Web.Mvc;

namespace Concessionaria.Web.Controllers
{
    public class DetalhesVendaController : BaseController
    {
        // GET: DetalhesVenda
        public ActionResult Index()
        {
            return View();
        }
    }
}