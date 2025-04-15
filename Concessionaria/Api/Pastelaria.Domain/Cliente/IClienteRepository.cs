

using Concessionaria.Domain.Cliente.Dto;
using System.Collections.Generic;

namespace Concessionaria.Domain.Cliente
{
    public interface IClienteRepository
    {
        
        IEnumerable<ClienteDto> Get();// Método para obter todos os Clientes
        ClienteDto GetId(int idCliente);

        int Post(ClienteDto cliente); 
   
        ClienteDto PutDesativaCliente(int IdCliente);
        ClienteDto GetCpf(string cpf); // Método para obter um Cliente pelo CPF
        void Put(ClienteDto cliente);
        void Delete(int Idcliente);
     

    }
}
