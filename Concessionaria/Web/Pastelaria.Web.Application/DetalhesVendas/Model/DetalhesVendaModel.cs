

using System;

namespace Concessionaria.Web.Application.DetalhesVendas.Model
{
    public class DetalhesVendaModel
    {
        public int IdVenda { get; set; }
        public decimal ValorCarro { get; set; }
        public decimal ValorNegociado { get; set; }
        public decimal ValorEntrada { get; set; }
        public int Parcelas { get; set; }
        public decimal ValorParcela { get; set; }
        public string NomeModelo { get; set; }
        public string NomeMarca { get; set; }
        public string NomeMotorizacao { get; set; }
        public string NomeCarroceria { get; set; }
        public string Tipo { get; set; }
        public string Potencia { get; set; }
        public string Cor { get; set; }
        public int Ano { get; set; }
        public bool MotorTurbo { get; set; }
        public string Detalhes { get; set; }
        public string CPF { get; set; }
        public string NomeCliente { get; set; }
        public DateTime DataNascimento { get; set; }
    }
}
