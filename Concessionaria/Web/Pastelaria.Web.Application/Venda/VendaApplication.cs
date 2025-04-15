
using Concessionaria.Web.Application.Infra;
using Concessionaria.Web.Application.Infra.Extensions;
using System;
using System.Collections.Generic;

namespace Concessionaria.Web.Application.Venda
{
    public class VendaApplication : BaseApplication
    {

        public VendaApplication() : base($"http://localhost:51169/api/venda")
        {
        }
        public Response<IEnumerable<VendaModel>> Buscarvendas()
          => Request.Get("todas").AsResponse<IEnumerable<VendaModel>>();

        public Response Post(VendaModel venda)
        {
            // Verifique o valor antes de enviar
            Console.WriteLine($"Valor da parcela antes de enviar: {venda.ValorParcela}");
            var response = Request.Post(venda).AsResponse();

            return response;
        }



    }
}
