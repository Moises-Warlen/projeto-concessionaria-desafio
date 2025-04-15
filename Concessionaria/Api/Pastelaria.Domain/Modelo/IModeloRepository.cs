using Concessionaria.Domain.Modelo.Dto;
using System.Collections.Generic;

namespace Concessionaria.Domain.Modelo
{
   public interface IModeloRepository
    {
        // Obtém todos os modelos
        IEnumerable<ModeloDto> ListarTodosModelos();
        IEnumerable<ModeloDto> ListarAllModelosOrName();
        // Obtém um modelo pelo seu identificador
        ModeloDto ListarPorid(int id);

        // Adiciona um novo modelo
        int Post(ModeloDto modelo);

        // Atualiza um modelo existente
        void Put(ModeloDto modelo);

        int ValidarModeloEstoque(int id);

        // Remove um modelo pelo seu identificador
        void Delete(int id);
    }
}

