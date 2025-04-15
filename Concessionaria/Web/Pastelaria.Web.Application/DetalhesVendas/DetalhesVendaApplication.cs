

using Concessionaria.Web.Application.DetalhesVendas.Model;
using Concessionaria.Web.Application.Infra;
using Concessionaria.Web.Application.Infra.Extensions;

namespace Concessionaria.Web.Application.DetalhesVendas
{
    public class DetalhesVendaApplication : BaseApplication
    {
        public DetalhesVendaApplication() : base($"http://localhost:51169/api/detalhesvenda")
        {
        }
        public Response<DetalhesVendaModel> BuscarDetalhesPorId(int id)
           => Request.Get($"{id}").AsResponse<DetalhesVendaModel>();
    }
}
