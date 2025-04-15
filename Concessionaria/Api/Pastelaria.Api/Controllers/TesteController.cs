using Concessionaria.Api.Infra.Configuration;
using Concessionaria.Domain.Teste;
using Concessionaria.Domain.Teste.Dto;
using System.Web.Http;

namespace Concessionaria.Api.Controllers
{
    [RoutePrefix("api/teste")]
    public class TesteController : AuthApiController
    {
        private readonly ITesteRepository _testeRepository;

        public TesteController(ITesteRepository testeRepository)
        {
            _testeRepository = testeRepository;
        }

        [HttpGet, Route("todos")]
        public IHttpActionResult GetTestes()
        {
            return Ok(_testeRepository.Get());
        }


        [HttpPost, Route("")]
        public IHttpActionResult Post(TesteDto teste)
        {
            _testeRepository.Post(teste);

            return Ok();
        }
    }
}
