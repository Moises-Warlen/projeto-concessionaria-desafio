using Concessionaria.Web.Application.Marca.Model;
using Concessionaria.Web.Application.Motorizacao.Model;
using Concessionaria.Web.Application.TipoCarroceria.Model;
using System.Collections.Generic;

namespace Concessionaria.Web.Application.Modelo.Model
{
    // Modelos de Visualização para Adicionar e Editar
    public class AdicionarModeloViewModel
    {
       
        public ModeloModel Modelo { get; set; }
        public IEnumerable<MarcaModel> Marcas { get; set; }
        public IEnumerable<MotorizacaoModel> Motorizacoes { get; set; }
        public IEnumerable<TipoCarroceriaModel> TiposCarroceria { get; set; }
        public int AnoMinimo { get; set; }
        public int AnoMaximo { get; set; }
    }
}
