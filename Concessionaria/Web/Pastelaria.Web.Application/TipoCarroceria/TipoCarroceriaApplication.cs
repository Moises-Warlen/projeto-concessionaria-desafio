using Concessionaria.Web.Application.Infra;
using Concessionaria.Web.Application.Infra.Extensions;
using Concessionaria.Web.Application.TipoCarroceria.Model;
using System.Collections.Generic;

namespace Concessionaria.Web.Application.TipoCarroceria
{
    public class TipoCarroceriaApplication : BaseApplication
    {
        public TipoCarroceriaApplication() : base($"http://localhost:51169/api/carroceria")
        {
        }
        public Response<IEnumerable<TipoCarroceriaModel>> BuscarTiposCarroceria()
          => Request.Get("todos").AsResponse<IEnumerable<TipoCarroceriaModel>>();
        public Response<TipoCarroceriaModel> BuscarTipoPorId(int id)
        => Request.Get($"{id}").AsResponse<TipoCarroceriaModel>();
    }
}
