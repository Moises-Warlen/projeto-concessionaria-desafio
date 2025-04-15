
using Concessionaria.Api.Infra.Configuration;
using Concessionaria.Domain.Endereco;
using System.Web.Http;

namespace Concessionaria.Api.Controllers
{
    [RoutePrefix("api/endereco")]
    public class EnderecoController : AuthApiController
    {
        private readonly IEnderecoRepository _enderecoRepository;

        public EnderecoController(IEnderecoRepository enderecoRepository)
        {
            _enderecoRepository = enderecoRepository;
        }

      

        // Endpoint para obter endereco de um cliente específico baseado no ID do endereco.
        [HttpGet, Route("{id:int}")]
        public IHttpActionResult Get(int id)
        {
            var endereco = _enderecoRepository.GetId(id); // Obtém a lista de endereco para o ID fornecido.
            return Ok(endereco); // Retorna a lista de Email com um código de status HTTP 200 (OK).
        }

        // Endpoint para deletar um endereco baseado no ID do endereco.
        [HttpDelete, Route("{id}")]
        public IHttpActionResult Delete(int id)
        {
            _enderecoRepository.DeleteEnderecoCliente(id); // Deleta o endereco com o ID fornecido.

            return Ok(); // Retorna um código de status HTTP 200 (OK) indicando que a operação foi bem-sucedida.
        }
    }
}