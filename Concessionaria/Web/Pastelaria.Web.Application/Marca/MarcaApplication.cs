using Concessionaria.Web.Application.Infra;
using Concessionaria.Web.Application.Infra.Extensions;
using Concessionaria.Web.Application.Marca.Model;
using System.Collections.Generic;

namespace Concessionaria.Web.Application.Marca
{
    public class MarcaApplication : BaseApplication
    {
        public MarcaApplication() : base($"http://localhost:51169/api/marca")
        {

        }

        // Método para criar uma nova marca, enviando uma requisição POST
        public Response Post(MarcaModel marca)
        {
            return Request.Post(marca).AsResponse();
        }

        // Método para atualizar uma marca existente pelo Id, enviando uma requisição PUT
        public Response Put( MarcaModel marca)
        {
            return Request.Put( marca).AsResponse();
        }

        // Método para deletar uma marca pelo Id, enviando uma requisição DELETE
        public Response Delete(int id)
        {
            // Removendo duplicação da chamada de DELETE
            return Request.Delete(id).AsResponse();
        }

        // Método para obter uma lista de todas as marcas, enviando uma requisição GET para o endpoint "todas"
        public Response<IEnumerable<MarcaModel>> BuscarMarcas()
            => Request.Get("todas").AsResponse<IEnumerable<MarcaModel>>();

        // Método para obter um usuário específico pelo ID, enviando uma requisição GET
        public Response<MarcaModel> BuscarMarcaPorId(int id)
            => Request.Get($"{id}").AsResponse<MarcaModel>();

        public Response<bool> ValidarMarcaEmodelo(int id)
        {
            return Request.Get($"{id}/validar").AsResponse<bool>();
        }
    }
}
