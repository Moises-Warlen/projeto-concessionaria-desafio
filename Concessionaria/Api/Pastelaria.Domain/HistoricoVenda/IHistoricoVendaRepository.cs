using Concessionaria.Domain.Venda.Dto;
using System.Collections.Generic;

namespace Concessionaria.Domain.Venda
{
   public  interface IHistoricoVendaRepository
    {
       IEnumerable<HistoricoVendaDto> ListarTodasVendas();// Método para obter todos os Clientes
    }
}
