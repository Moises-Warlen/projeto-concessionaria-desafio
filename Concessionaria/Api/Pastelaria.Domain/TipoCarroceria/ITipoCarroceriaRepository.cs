
using Concessionaria.Domain.Carroceria.Dto;
using System.Collections.Generic;

namespace Concessionaria.Domain.TipoCarroceria
{
   public  interface ITipoCarroceriaRepository
    {
        IEnumerable<TipoCarroceriaDto> ListasTiposCarroceria();
        TipoCarroceriaDto ListarPorid(int id);
    }
}
