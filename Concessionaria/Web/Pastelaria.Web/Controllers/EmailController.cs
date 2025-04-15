
using Concessionaria.Web.Application.Email;
using Concessionaria.Web.Application.Email.Model;
using Concessionaria.Web.Infra;
using System.Web.Mvc;

namespace Concessionaria.Web.Controllers
{
    public class EmailController : BaseController
    {
        private readonly EmailApplication _emailApplication;

        public EmailController(EmailApplication emailApplication)
        {
            _emailApplication = emailApplication;
        }

        [HttpPost]
        public ActionResult LinhaGrid(EmailModel email)
        {
          
            return View("_LinhaGridEmail", email);
        }

        public ActionResult Deletar(int id)
        {
           
            _emailApplication.Delete(id);

          
            return Success();
        }
    }
}