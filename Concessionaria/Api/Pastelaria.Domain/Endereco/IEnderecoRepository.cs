
using Concessionaria.Domain.Endereco.Dto;
using System.Collections.Generic;

namespace Concessionaria.Domain.Endereco
{
    public interface IEnderecoRepository
    {
        IEnumerable<EnderecoDto> Get(); // Método para obter uma coleção de objetos EnderecoDto

        IEnumerable<EnderecoDto> GetId(int id ); // Método para obter uma coleção de objetos EnderecoDto pelo id

        void Post(int idCliente, EnderecoDto endereco);  // Método para adicionar um novo endereço para um cliente específico

        void Delete(int id);  // Método para excluir um endereço pelo seu id

        void DeleteEnderecoCliente(int id);   // Método para excluir todos os endereços associados a um Cliente específico
    }
}
