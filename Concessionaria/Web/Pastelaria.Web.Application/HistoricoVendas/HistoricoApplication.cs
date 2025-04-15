using Concessionaria.Web.Application.HistoricoVendas.Model;
using Concessionaria.Web.Application.Infra;
using Concessionaria.Web.Application.Infra.Extensions;
using System.Collections.Generic;

namespace Concessionaria.Web.Application.HistoricoVendas
{
    public class HistoricoApplication : BaseApplication
    {
        public HistoricoApplication() : base($"http://localhost:51169/api/historicovendas")
        {
        }
        public Response<IEnumerable<HistoricoVendaModel>> BuscarHistoricoVendas()
     => Request.Get("todas").AsResponse<IEnumerable<HistoricoVendaModel>>();

    }
   
}

