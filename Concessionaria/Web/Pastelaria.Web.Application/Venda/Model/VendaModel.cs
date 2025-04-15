using Concessionaria.Web.Application.Cliente.Model;
using Concessionaria.Web.Application.Estoque.Model;
using System;


namespace Concessionaria.Web.Application.Venda
{
    public  class VendaModel
    {
        public int IdVenda{ get; set; }
        public ClienteModel Cliente { get; set; }
        public EstoqueModel Estoque { get; set; }
        public decimal ValorNegociado { get; set; }
        public decimal? ValorEntrada { get; set; }
        public decimal ValorSugerido { get; set; } // somente leitura
        public int Parcelas { get; set; }
        public decimal ValorParcela { get; set; } // somente leitura
        public bool Disponivel { get; set; }
        public DateTime DataVenda { get; set; }


    }
}
