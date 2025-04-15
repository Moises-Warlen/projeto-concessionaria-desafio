using Concessionaria.Domain.Telefone.Dto;
using System.Collections.Generic;
namespace Concessionaria.Domain.Telefone
{
     public interface ITelefoneRepository
    {
        IEnumerable<TelefoneDto> Get();

        IEnumerable<TelefoneDto> Get(int? id = null, string nome = null);

        void Post(int IdCliente ,TelefoneDto telefone);
        void Delete(int id);
        void DeletePorCliente(int id);
    }
}
