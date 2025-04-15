using Concessionaria.Web.Application.Marca.Model;
using Concessionaria.Web.Application.Motorizacao.Model;
using Concessionaria.Web.Application.TipoCarroceria.Model;

namespace Concessionaria.Web.Application.Modelo.Model
{
    public  class ModeloModel
    {
        public int IdModelo { get; set; }
        public string Modelo { get; set; }
        public MarcaModel Marca { get; set; }
        public MotorizacaoModel Potencia { get; set; }
        public TipoCarroceriaModel Tipo { get; set; }
        public int AnoMinimo { get; set; }
        public int AnoMaximo { get; set; }                  
    }
}
