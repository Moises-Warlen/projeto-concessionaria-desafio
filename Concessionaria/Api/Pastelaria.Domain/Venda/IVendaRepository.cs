
using Concessionaria.Domain.Venda.Dto;

namespace Concessionaria.Domain.Venda
{
   public interface IVendaRepository
    {
        int Post(VendaDto venda);
    }
}
