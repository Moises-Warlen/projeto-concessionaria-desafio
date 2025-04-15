
using Concessionaria.Api.Infra.Configuration;
using Concessionaria.Domain.Estoque;
using Concessionaria.Domain.Estoque.Dto;
using System.Web.Http;

namespace Concessionaria.Api.Controllers
{
    [RoutePrefix("api/estoque")]
    public class EstoqueController : AuthApiController
    {
        private readonly IEstoqueRepository _estoqueRepository;
        public EstoqueController(IEstoqueRepository estoqueRepository)
        {
            _estoqueRepository = estoqueRepository;
        }

        [HttpGet, Route("todos")]
        public IHttpActionResult Buscarstoque()
        {
            return Ok(_estoqueRepository.ListarEstoques());
        }



        [HttpGet, Route("{id:int}")]
        public IHttpActionResult BuscarEstoqueoPorId(int id)
        {
            var estoque = _estoqueRepository.ListarEstoquePorId(id);

            return Ok(estoque);
        }


        [HttpPost, Route("")]
        public IHttpActionResult Post(EstoqueDto estoque)
        {
            var idEstoque = _estoqueRepository.Post(estoque);
            return Ok();
        }


        [HttpPut, Route("")]
        public IHttpActionResult Put(EstoqueDto estoque)
        {
            _estoqueRepository.Put(estoque);
            return Ok();
        }

        // Endpoint para deletar uma marca baseada no Id
        [HttpDelete, Route("{id}")]
        public IHttpActionResult Delete(int id)
        {
            _estoqueRepository.Delete(id); // Deleta a marca com Id fornecido

            return Ok(); // Retorna um código de status HTTP 200 (OK) indicando que a operação foi bem-sucedida.
        }

    }

   
}



