using Concessionaria.Api.Infra.Configuration;
using Concessionaria.Domain.Modelo;
using Concessionaria.Domain.Modelo.Dto;
using System.Web.Http;

namespace Concessionaria.Api.Controllers
{
    [RoutePrefix("api/modelo")]
    public class ModeloController : AuthApiController
    {
        private readonly IModeloRepository _modeloRepository;
        public ModeloController(IModeloRepository modeloRepository)
        {
            _modeloRepository = modeloRepository;
        }

        [HttpGet, Route("todos")]
        public IHttpActionResult ListarModelos()
        {
            return Ok(_modeloRepository.ListarTodosModelos());
        }
        [HttpGet, Route("allorname")]
        public IHttpActionResult ListarAllModeloOrName()
        {
            return Ok(_modeloRepository.ListarAllModelosOrName());
        }

        [HttpGet, Route("{id:int}")]
        public IHttpActionResult ListarModeloPorId(int id)
        {
            var modelo = _modeloRepository.ListarPorid(id);

            return Ok(modelo); // Retorna 200 com os dados da marca encontrada
        }


        // Endpoint para criar uma marca
        [HttpPost, Route("")]
        public IHttpActionResult Post(ModeloDto modelo)
        {
            var idModelo = _modeloRepository.Post(modelo);
            return Ok();
        }

        // Endpoint para Editar uma modelo
        [HttpPut, Route("")]
        public IHttpActionResult Put(ModeloDto modelo)
        {
            _modeloRepository.Put(modelo);
            return Ok();
        }

        [HttpGet, Route("{id:int}/validar")]
        public IHttpActionResult ValidarModeloEstoque(int id)
        {
            var resultadoValidacao = _modeloRepository.ValidarModeloEstoque(id);
            return Ok(resultadoValidacao); // Retorna o valor 1 ou 0 para o cliente
        }

        // Endpoint para deletar uma marca baseada no Id
        [HttpDelete, Route("{id}")]
        public IHttpActionResult Delete(int id)
        {
            _modeloRepository.Delete(id); // Deleta a marca com Id fornecido

            return Ok(); // Retorna um código de status HTTP 200 (OK) indicando que a operação foi bem-sucedida.
        }
    }
}