
using Concessionaria.Domain.Venda.Dto;

namespace Concessionaria.Domain.Venda
{
    public interface IDetalhesRepositoy
    {
        DetalhesDto ListarPorid(int id);
    }
}
