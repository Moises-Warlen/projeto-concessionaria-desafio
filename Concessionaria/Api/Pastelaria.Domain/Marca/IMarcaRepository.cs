using Concessionaria.Domain.Marca.Dto;
using System.Collections.Generic;

namespace Concessionaria.Domain.Marca
{
     public interface IMarcaRepository
    {
        IEnumerable<MarcaDto>ListarTodasMarcas();
        MarcaDto ListarPorid(int id);

        int Post(MarcaDto marca);

        int ValidarMarcaEmodelo(int id);

        void Put(MarcaDto marca);

        void Delete(int id);
    }
}
