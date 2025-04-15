using Concessionaria.Web.Application.Cliente.Model;
using Concessionaria.Web.Application.Estoque.Model;
using System;
using System.Collections.Generic;

namespace Concessionaria.Web.Application.Venda.Model
{
    public class AdicionarVendaViewModel
    {


        public IEnumerable<ClienteModel> Clientes { get; set; }
        public IEnumerable<EstoqueModel> Estoques { get; set; }
        public DateTime DataVenda { get; set; }
        public decimal ValorSugerido { get; set; } // somente leitura
        public decimal ValorEntrada { get; set; }
        public int QuantidadesParcelas { get; set; }
        public decimal ValorDaParcela { get; set; } // somente leitura

    }
}
