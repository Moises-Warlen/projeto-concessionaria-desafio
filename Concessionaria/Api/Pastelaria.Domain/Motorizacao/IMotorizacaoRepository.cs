using Concessionaria.Domain.Motorizacao.Dto;
using System.Collections.Generic;

namespace Concessionaria.Domain.Motorizacao
{
    public  interface IMotorizacaoRepository
    {
        // Obtém todas as potencia dos motores
        IEnumerable<MotorizacaoDto> ListarTodasPotencias();

        MotorizacaoDto ListarPorid(int id);
    }
}
