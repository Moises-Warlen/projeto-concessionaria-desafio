using Concessionaria.Web.Application.Infra;
using Concessionaria.Web.Application.Infra.Extensions;
using Concessionaria.Web.Application.Modelo.Model;
using System.Collections.Generic;

namespace Concessionaria.Web.Application.Modelo
{
    public class ModeloApplication : BaseApplication
    {
        public ModeloApplication() : base($"http://localhost:51169/api/modelo")
        {
        }
         public Response<IEnumerable<ModeloModel>> BuscarModelos()
           => Request.Get("todos").AsResponse<IEnumerable<ModeloModel>>();
       
        public Response<IEnumerable<ModeloModel>> BuscarPorNome()
         => Request.Get("allorname").AsResponse<IEnumerable<ModeloModel>>();
     
        public Response<ModeloModel> BuscarModeloPorId(int id)
            => Request.Get($"{id}").AsResponse<ModeloModel>();
      
        public Response Post(ModeloModel modelo)
        {
            return Request.Post(modelo).AsResponse();
        }


        // Método para atualizar um modelo existente pelo Id, enviando uma requisição PUT
        public Response Put(ModeloModel modelo)
        {
            return Request.Put(modelo).AsResponse();
        }

        // Método para deletar um modelo pelo Id, enviando uma requisição DELETE
        public Response Delete(int id)
        {
          
            return Request.Delete(id).AsResponse();
        }
        public Response<bool> ValidarModeloEstoque(int id)
        {
            return Request.Get($"{id}/validar").AsResponse<bool>();
        }

    }
}







