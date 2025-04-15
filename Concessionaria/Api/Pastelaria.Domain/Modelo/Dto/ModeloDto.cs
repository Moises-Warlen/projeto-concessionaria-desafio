using Concessionaria.Domain.Carroceria.Dto;
using Concessionaria.Domain.Marca.Dto;
using Concessionaria.Domain.Motorizacao.Dto;

namespace Concessionaria.Domain.Modelo.Dto
{
    public class ModeloDto
    {
        public int IdModelo { get; set; } 
        public string Modelo { get; set; }                     
        public MarcaDto Marca { get; set; }                 
        public MotorizacaoDto Potencia { get; set; }      
        public TipoCarroceriaDto Tipo { get; set; }    
        public int AnoMinimo { get; set; }                    
        public int AnoMaximo { get; set; }                    
    }

}

