using Concessionaria.Web.Application.Endereco.Model;
using Concessionaria.Web.Application.Infra;
using Concessionaria.Web.Application.Infra.Extensions;
using System.Collections.Generic;

namespace Concessionaria.Web.Application.Endereco
{
    public class EnderecoApplication : BaseApplication
    {
        public EnderecoApplication() : base($"http://localhost:51169/api/endereco")
        {
        }

        // Método para enviar um novo endereço (POST) para a API
        public Response Post(EnderecoModel endereco)
        {
            return Request.Post(endereco).AsResponse();
        }

        // Método para excluir um endereço existente (DELETE) da API usando o ID
        public Response Delete(int id)
        {
            return Request.Delete(id).AsResponse();
        }

        // Método para obter todos os endereços (GET) da API
        public Response<IEnumerable<EnderecoModel>> GetEnderecos()
        {
            return Request.Get("todos").AsResponse<IEnumerable<EnderecoModel>>();
        }

        // Método para obter um endereço específico (GET) da API usando o ID
        public Response<IEnumerable<EnderecoModel>> GetEndereco(int id) =>
         Request.Get($"{id}").AsResponse<IEnumerable<EnderecoModel>>();
    }
}
