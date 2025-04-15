using Concessionaria.Api.Infra.Configuration;
using Concessionaria.Domain.Motorizacao;
using System.Web.Http;

namespace Concessionaria.Api.Controllers
{
    [RoutePrefix("api/motorizacao")]
    public class MotorizacaoController : AuthApiController
    {
        private readonly IMotorizacaoRepository _motorizacaoRepository;
        public MotorizacaoController(IMotorizacaoRepository motorizacaoRepository)
        {
            _motorizacaoRepository = motorizacaoRepository;
        }

        [HttpGet, Route("todas")]
        public IHttpActionResult ListarTodasPotencias()
        {
            return Ok(_motorizacaoRepository.ListarTodasPotencias());
        }

        [HttpGet, Route("{id:int}")]
        public IHttpActionResult ListarPotenciaPorId(int id)
        {
            var potencia = _motorizacaoRepository.ListarPorid(id);

            return Ok(potencia); // Retorna 200 com os dados 
        }
    }
}