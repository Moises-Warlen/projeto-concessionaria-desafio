using Concessionaria.Api.Infra.Configuration;
using Concessionaria.Domain.Venda;
using Concessionaria.Domain.Venda.Dto;
using System;
using System.Web.Http;

namespace Concessionaria.Api.Controllers
{
    [RoutePrefix("api/venda")]
    public class VendaController : AuthApiController
    {
        private readonly IHistoricoVendaRepository _vendaRepository;
        private readonly IVendaRepository _vendasRepository;

        public VendaController(IHistoricoVendaRepository vendaRepository , IVendaRepository vendasRepository)
        {
            _vendaRepository = vendaRepository;
           _vendasRepository = vendasRepository;
        }

        [HttpGet, Route("todas")]
        public IHttpActionResult Get()
        {
            var historicoVendas = _vendaRepository.ListarTodasVendas();

            // Verifique o valor antes de retornar
            foreach (var venda in historicoVendas)
            {
                Console.WriteLine($"Valor da parcela antes de enviar: {venda}");
            }

            return Ok(historicoVendas);
        }

        [HttpPost, Route("")]
        public IHttpActionResult Post(VendaDto venda)
        {
            // Verifique o valor ao receber
            Console.WriteLine($"Valor da parcela recebida: {venda}");

            var idVenda = _vendasRepository.Post(venda);
            return Ok();
        }


    }
}