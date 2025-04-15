
using Concessionaria.Web.Application.Endereco;
using Concessionaria.Web.Application.Endereco.Model;
using Concessionaria.Web.Infra;
using System.Web.Mvc;

namespace Concessionaria.Web.Controllers
{
    public class EnderecoController : BaseController
    {
        private readonly EnderecoApplication _enderecoApplication;
        public EnderecoController(EnderecoApplication enderecoApplication)
        {
            _enderecoApplication = enderecoApplication;
        }
        [HttpPost]
        public ActionResult LinhaGrid(EnderecoModel endereco)
        {
            // Retorna a view parcial "_LinhaGridEndereco" com o modelo de Endereço fornecido
            return View("_LinhaGridEndereco", endereco);
        }
        public ActionResult Deletar(int id)
        {
            // Chama o método de deletar da aplicação de Endereço
            _enderecoApplication.Delete(id);

            // Retorna um resultado de sucesso (presumivelmente definido em BaseController)
            return Success();
        }
    }
}