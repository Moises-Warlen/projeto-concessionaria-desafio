
using Concessionaria.Domain.Estoque.Dto;

using System.Collections.Generic;


namespace Concessionaria.Domain.Estoque
{
    public  interface IEstoqueRepository
    {
        // Obtém todo estoque
       IEnumerable<EstoqueDto> ListarEstoques();
        EstoqueDto ListarEstoquePorId(int id);

        int Post(EstoqueDto estoque);
        void Delete(int id);
        void Put(EstoqueDto estoque);
        void Vendido(EstoqueDto estoque);

    }
}
