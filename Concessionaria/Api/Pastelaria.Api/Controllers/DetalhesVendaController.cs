using Concessionaria.Api.Infra.Configuration;
using Concessionaria.Domain.Venda;
using System.Web.Http;


namespace Concessionaria.Api.Controllers
{
    [RoutePrefix("api/detalhesvenda")]
    public class DetalhesVendaController : AuthApiController
    {
        private readonly IDetalhesRepositoy _detalhesRepository;
        public DetalhesVendaController(IDetalhesRepositoy detalhesRepository)
        {
            _detalhesRepository = detalhesRepository;
        }


        [HttpGet, Route("{id:int}")]
        public IHttpActionResult ListarMarcaPorId(int id)
        {
            var detalhes = _detalhesRepository.ListarPorid(id);

          

            return Ok(detalhes); // Retorna 200 com os dados da marca encontrada
        }

           
        
    }
}