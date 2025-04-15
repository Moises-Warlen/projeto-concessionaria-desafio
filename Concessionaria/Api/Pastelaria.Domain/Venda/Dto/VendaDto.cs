using Concessionaria.Domain.Cliente.Dto;
using Concessionaria.Domain.Estoque.Dto;
using System;


namespace Concessionaria.Domain.Venda.Dto
{
   public class VendaDto
    {
        public int IdVenda { get; set; }
        public ClienteDto Cliente { get; set; }
        public EstoqueDto Estoque { get; set; }
        public decimal ValorNegociado { get; set; }
        public decimal? ValorEntrada { get; set; }
        public decimal ValorSugerido { get; set; } // somente leitura
        public int Parcelas { get; set; }
        public decimal ValorParcela { get; set; } // somente leitura
        public bool Disponivel { get; set; }
        public DateTime DataVenda { get; set; }

    }
}
