using Concessionaria.Web.Application.Teste;
using Concessionaria.Web.Application.Teste.Model;
using Concessionaria.Web.Infra;
using System.Web.Mvc;

namespace Concessionaria.Web.Controllers
{
    public class testeController : BaseController
    {
        private readonly TesteApplication _testeApplication;

        public testeController(TesteApplication testeApplication)
        {
            _testeApplication = testeApplication;
        }

        public ActionResult Index1()
        {
            return View(_testeApplication.Get());
        }

        public ActionResult GetGrid()
        {
            var response = _testeApplication.GetTestes();
            if (!response.Ok)
                return Error(response.Messages);

            return View("_GridTestes1", response.Content);
        }

        public ActionResult Post(TesteModel teste)
        {
            var response = _testeApplication.Post(teste);
            if (!response.Ok)
                return Error(response.Messages);

            return Success();
        }

        public ActionResult Put(TesteModel teste)
        {
            return Success();
        }

        public ActionResult Delete(int identificador)
        {
            return Success();
        }


        public ActionResult Sobre()
        {
            return View("Sobre");
        }
    }
}