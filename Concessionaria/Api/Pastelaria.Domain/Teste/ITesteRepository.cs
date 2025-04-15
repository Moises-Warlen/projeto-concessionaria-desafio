using Concessionaria.Domain.Teste.Dto;
using System.Collections.Generic;

namespace Concessionaria.Domain.Teste
{
    public interface ITesteRepository
    {
        IEnumerable<TesteDto> Get();
        void Post(TesteDto teste);
    }
}