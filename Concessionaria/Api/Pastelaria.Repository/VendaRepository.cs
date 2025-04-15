
using Concessionaria.Domain.Venda;
using Concessionaria.Domain.Venda.Dto;
using Concessionaria.Repository.Infra;

namespace Concessionaria.Repository
{
    public class VendaRepository : BaseRepository, IVendaRepository
    {
        public VendaRepository(IDatabaseConnection connection) : base(connection)
        {
        }

        private enum Procedures
        {
            AdicionarVenda,
        }

        public int Post(VendaDto venda)
        {
            ExecuteProcedure(Procedures.AdicionarVenda);
            AddParameter("@IdCliente",venda.Cliente.IdCliente);
            AddParameter("@IdEstoque", venda.Estoque.IdEstoque);
            AddParameter("@ValorNegociado", venda.ValorNegociado);
            AddParameter("@ValorEntrada", venda.ValorEntrada);
            AddParameter("@Parcelas", venda.Parcelas);
            AddParameter("@ValorParcela", venda.ValorParcela);

            return ExecuteNonQueryWithReturn<int>();
        }
    }
}
