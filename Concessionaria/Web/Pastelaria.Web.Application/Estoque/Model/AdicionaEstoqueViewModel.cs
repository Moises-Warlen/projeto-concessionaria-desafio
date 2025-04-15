using Concessionaria.Web.Application.Modelo.Model;
using System.Collections.Generic;

namespace Concessionaria.Web.Application.Estoque.Model
{
    public  class AdicionaEstoqueViewModel
    {
        public EstoqueModel Estoque { get; set; }
        public IEnumerable<ModeloModel> Modelo { get; set; }
        public int? AnoMinimo { get; set; } 
        public int? AnoMaximo { get; set; } 
    }
}
