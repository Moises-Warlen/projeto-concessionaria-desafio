using Concessionaria.Api.Infra.Configuration;
using Concessionaria.Domain.Venda;
using System.Web.Http;

namespace Concessionaria.Api.Controllers
{
    [RoutePrefix("api/historicovendas")]
    public class HistoricoVendasController : AuthApiController
    {
        private readonly IHistoricoVendaRepository _vendaRepository;

        public HistoricoVendasController(IHistoricoVendaRepository vendaRepository)
        {
            _vendaRepository = vendaRepository;
        }

        [HttpGet, Route("todas")]
        public IHttpActionResult Get()
        {
            var historicoVendas = _vendaRepository.ListarTodasVendas();
            return Ok(historicoVendas);
        }
    }
}