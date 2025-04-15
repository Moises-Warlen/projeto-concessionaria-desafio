
using Concessionaria.Web.Application.Telefone;
using Concessionaria.Web.Application.Telefone.Model;
using Concessionaria.Web.Infra;
using System.Web.Mvc;

namespace Concessionaria.Web.Controllers
{
    public class TelefoneController : BaseController
    {
        private readonly TelefoneApplication _telefoneApplication;
        public TelefoneController(TelefoneApplication telefoneApplication)
        {
            _telefoneApplication = telefoneApplication;
        }

        [HttpPost]
        public ActionResult LinhaGrid(TelefoneModel telefone)
        {
          
            return View("_LinhaGridTelefone", telefone);
        }

      
        public ActionResult Deletar(int id)
        {
           
            _telefoneApplication.Delete(id);
           
            return Success(); 
        }
    }
}