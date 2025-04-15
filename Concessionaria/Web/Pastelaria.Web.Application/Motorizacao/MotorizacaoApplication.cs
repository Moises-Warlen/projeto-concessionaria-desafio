using Concessionaria.Web.Application.Infra;
using Concessionaria.Web.Application.Infra.Extensions;
using Concessionaria.Web.Application.Motorizacao.Model;
using System.Collections.Generic;

namespace Concessionaria.Web.Application.Motorizacao
{
    public class MotorizacaoApplication : BaseApplication
    {
        public MotorizacaoApplication() : base($"http://localhost:51169/api/motorizacao")
        {
        }
    
        public Response<IEnumerable<MotorizacaoModel>> BuscarTodasPotencias()
          => Request.Get("todas").AsResponse<IEnumerable<MotorizacaoModel>>();
        public Response<MotorizacaoModel>buscarPotenciaPorId(int id)
         => Request.Get($"{id}").AsResponse<MotorizacaoModel>();
    }
}
