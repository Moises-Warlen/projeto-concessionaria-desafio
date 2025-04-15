

using Concessionaria.Web.Application.Cliente.Model;
using Concessionaria.Web.Application.Infra;
using Concessionaria.Web.Application.Infra.Extensions;
using System.Collections.Generic;

namespace Concessionaria.Web.Application.Cliente
{
    public class ClienteApplication : BaseApplication
    {
        public ClienteApplication() : base($"http://localhost:51169/api/cliente")
        {
        }
        public Response Post(ClienteModel cliente)
        {
            return Request.Post(cliente).AsResponse();
        }
        public void Put(ClienteModel cliente)
        {
            // A implementação do método Put deve ser adicionada aqui para atualizar um cliente existente
        }

        // Método para obter uma lista de todos os clientes, enviando uma requisição GET para o endpoint "todos"
        public Response<IEnumerable<ClienteModel>> GetClientes()
            => Request.Get("todos").AsResponse<IEnumerable<ClienteModel>>();


        public Response Delete(int id)
        {
            // Envia uma requisição DELETE para o endpoint com o ID do usuário e retorna a resposta
            Request.Delete(id).AsResponse();
            return Request.Delete(id).AsResponse();
        }

        // Novo método para obter um cliente pelo CPF
        public Response<ClienteModel> GetClientePorCPF(string cpf)
        {
            return Request.Get($"cpf/{cpf}").AsResponse<ClienteModel>();
        }

        // Método para obter um cliente específico pelo ID, enviando uma requisição GET
        public Response<ClienteModel> GetCliente(int id)
        {
            return Request.Get($"{id}").AsResponse<ClienteModel>();
        }


    }
}
