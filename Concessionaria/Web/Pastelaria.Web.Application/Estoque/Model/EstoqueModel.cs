using Concessionaria.Web.Application.Modelo.Model;
using Concessionaria.Web.Application.Motorizacao.Model;
using Concessionaria.Web.Application.TipoCarroceria.Model;

namespace Concessionaria.Web.Application.Estoque.Model
{
    public class EstoqueModel
    {
        public int IdEstoque { get; set; }
        public ModeloModel Modelo { get; set; }
        public MotorizacaoModel Potencia { get; set; }
        public TipoCarroceriaModel Tipo { get; set; }
        public int Ano { get; set; }
        public bool MotorTurbo { get; set; }
        public string Detalhes { get; set; }
        public string Cor { get; set; }
        public decimal Valor { get; set; }
        public bool Disponivel { get; set; }
        public string Placa { get; set; }

    }
}
