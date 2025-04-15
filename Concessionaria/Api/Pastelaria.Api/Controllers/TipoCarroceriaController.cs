
using Concessionaria.Api.Infra.Configuration;
using Concessionaria.Domain.TipoCarroceria;
using System.Web.Http;

namespace Concessionaria.Api.Controllers
{
    [RoutePrefix("api/carroceria")]
    public class TipoCarroceriaController : AuthApiController
    {
        private readonly ITipoCarroceriaRepository _tipoCarroceriaRepository;
        public TipoCarroceriaController(ITipoCarroceriaRepository tipoCarroceriaRepository)
        {
            _tipoCarroceriaRepository = tipoCarroceriaRepository;
        }

        [HttpGet, Route("todos")]
        public IHttpActionResult ListasTiposCarroceria()
        {
            return Ok(_tipoCarroceriaRepository.ListasTiposCarroceria());
        }


        [HttpGet, Route("{id:int}")]
        public IHttpActionResult ListarPorId(int id)
        {
            var tipo = _tipoCarroceriaRepository.ListarPorid(id);

            return Ok(tipo); // Retorna 200 com os dados 
        }

    }
}

