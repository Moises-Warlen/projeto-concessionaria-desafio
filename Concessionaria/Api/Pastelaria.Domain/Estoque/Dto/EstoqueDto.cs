using Concessionaria.Domain.Carroceria.Dto;
using Concessionaria.Domain.Modelo.Dto;
using Concessionaria.Domain.Motorizacao.Dto;

namespace Concessionaria.Domain.Estoque.Dto
{
    public class EstoqueDto
    {
        public int IdEstoque { get; set; }
        public ModeloDto Modelo { get; set;}
        public MotorizacaoDto Potencia { get; set; }
        public TipoCarroceriaDto Tipo { get; set; }
        public int Ano { get; set; }
        public bool MotorTurbo { get; set; }
        public string Detalhes { get; set; }
        public string Cor { get; set; }
        public decimal Valor { get; set; }
        public bool Disponivel { get; set; }
        public string Placa { get; set; }
    }
}
