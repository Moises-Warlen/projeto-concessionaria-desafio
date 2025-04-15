
using Concessionaria.Web.Application.Infra;
using Concessionaria.Web.Application.Infra.Extensions;
using Concessionaria.Web.Application.Telefone.Model;
using System.Collections.Generic;

namespace Concessionaria.Web.Application.Telefone
{
    public class TelefoneApplication : BaseApplication
    {
        public TelefoneApplication() : base($"http://localhost:51169/api/telefone")
        {
        }
        public Response Post(TelefoneModel telefone)
        {
            return Request.Post(telefone).AsResponse();
        }
        public Response Delete(int id)
        {
            return Request.Delete(id).AsResponse();
        }
        public Response<IEnumerable<TelefoneModel>> GetTelefones() =>
          Request.Get("todos").AsResponse<IEnumerable<TelefoneModel>>();
        public Response<IEnumerable<TelefoneModel>> GetTelefone(int id) =>
           Request.Get($"{id}").AsResponse<IEnumerable<TelefoneModel>>();


    }
}
