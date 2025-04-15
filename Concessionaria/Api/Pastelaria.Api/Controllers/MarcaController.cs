using Concessionaria.Api.Infra.Configuration;
using Concessionaria.Domain.Marca;
using Concessionaria.Domain.Marca.Dto;
using System.Web.Http;


namespace Concessionaria.Api.Controllers
{
    [RoutePrefix("api/marca")]
    public class MarcaController : AuthApiController
    {
        private readonly IMarcaRepository _marcaRepository;
        public MarcaController(IMarcaRepository marcaRepository)
        {
            _marcaRepository = marcaRepository;
        }

        [HttpGet, Route("todas")]
        public IHttpActionResult ListarTodasMarcas()
        {
            return Ok(_marcaRepository.ListarTodasMarcas());
        }
       
        [HttpGet, Route("{id:int}")]
        public IHttpActionResult ListarMarcaPorId(int id)
        {
            var marca = _marcaRepository.ListarPorid(id);

            return Ok(marca); // Retorna 200 com os dados da marca encontrada
        }

        [HttpGet, Route("{id:int}/validar")]
        public IHttpActionResult ValidarMarcaEmodelo(int id)
        {
            var resultadoValidacao = _marcaRepository.ValidarMarcaEmodelo(id);
            return Ok(resultadoValidacao); // Retorna o valor 1 ou 0 para o cliente
        }




        // Endpoint para criar uma marca
        [HttpPost, Route("")]
        public IHttpActionResult Post(MarcaDto marca)
        {
            var idMarca = _marcaRepository.Post(marca);
            return Ok();
        }

        // Endpoint para Editar uma marca
        [HttpPut, Route("")]
        public IHttpActionResult Put(MarcaDto marca)
        {
           _marcaRepository.Put(marca);
            return Ok();
        }


        // Endpoint para deletar uma marca baseada no Id
        [HttpDelete, Route("{id}")]
        public IHttpActionResult Delete(int id)
        {
            _marcaRepository.Delete(id); // Deleta a marca com Id fornecido

            return Ok(); // Retorna um código de status HTTP 200 (OK) indicando que a operação foi bem-sucedida.
        }

    }
}

