
using Concessionaria.Api.Infra.Configuration;
using Concessionaria.Domain.Telefone;
using System.Web.Http;

namespace Concessionaria.Api.Controllers
{

    [RoutePrefix("api/telefone")]
    public class TelefoneController : AuthApiController
    {
        private readonly ITelefoneRepository _telefonerepository;

        public TelefoneController(ITelefoneRepository telefonerepository)
        {
            _telefonerepository = telefonerepository;
        }

        [HttpGet, Route("{id:int}")]
        public IHttpActionResult Get(int id)
        {
            var telefones = _telefonerepository.Get(id); 
            return Ok(telefones); 
        }

        // Endpoint para deletar um telefone baseado no ID do telefone.
        [HttpDelete, Route("{id}")]
        public IHttpActionResult Delete(int id)
        {
            _telefonerepository.DeletePorCliente(id); // Deleta o telefone com o ID fornecido.

            return Ok(); // Retorna um código de status HTTP 200 (OK) indicando que a operação foi bem-sucedida.
        }

    }
}
