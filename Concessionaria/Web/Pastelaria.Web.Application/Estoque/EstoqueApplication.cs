using Concessionaria.Web.Application.Estoque.Model;
using Concessionaria.Web.Application.Infra;
using Concessionaria.Web.Application.Infra.Extensions;
using System.Collections.Generic;

namespace Concessionaria.Web.Application.Estoque
{
    public class EstoqueApplication : BaseApplication
    {
        public EstoqueApplication() : base($"http://localhost:51169/api/estoque")
        {
        }
        public Response<IEnumerable<EstoqueModel>> BuscarEstoque()
          => Request.Get("todos").AsResponse<IEnumerable<EstoqueModel>>();

        public Response<IEnumerable<EstoqueModel>> BuscarTodosOuPorNome()
         => Request.Get("allorname").AsResponse<IEnumerable<EstoqueModel>>();

        public Response<EstoqueModel> BuscarEstoquePorId(int id)
          => Request.Get($"{id}").AsResponse<EstoqueModel>();

        // Método para criar um modelo, enviando uma requisição POST
        public Response Post(EstoqueModel estoque)
        {
            return Request.Post(estoque).AsResponse();
        }


        // Método para atualizar um modelo existente pelo Id, enviando uma requisição PUT
        public Response Put(EstoqueModel estoque)
        {
            return Request.Put(estoque).AsResponse();
        }

        // Método para deletar um modelo pelo Id, enviando uma requisição DELETE
        public Response Delete(int id)
        {

            return Request.Delete(id).AsResponse();
        }
     
    }
}
