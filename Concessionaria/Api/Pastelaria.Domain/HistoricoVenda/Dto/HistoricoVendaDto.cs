using System;

namespace Concessionaria.Domain.Venda.Dto
{
     public class HistoricoVendaDto
    {
        public int IdVenda { get; set; }
        public int IdCiente { get; set; }
        public string Cliente { get; set; }
        public string Modelo { get; set; }
        public string Tipo { get; set; }
        public string Potencia { get; set; }
        public DateTime DataVenda { get; set; }

    }
}
