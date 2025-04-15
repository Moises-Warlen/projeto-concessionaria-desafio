using Concessionaria.Domain.Email.Dto;
using System.Collections.Generic;

namespace Concessionaria.Domain.Email
{
   public interface IEmailRepository
    {
        IEnumerable<EmailDto> Get();
        IEnumerable<EmailDto> GetId(int id);
        void Post(int idCliente, EmailDto email);
        void DeleteEmailCliente(int id);
        void Delete(int id);
       
    }
}
