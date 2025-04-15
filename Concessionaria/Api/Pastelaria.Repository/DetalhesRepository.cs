
using Concessionaria.Domain.Venda;
using Concessionaria.Domain.Venda.Dto;
using Concessionaria.Repository.Infra;
using Concessionaria.Repository.Infra.Extensions;
using System.Linq;

namespace Concessionaria.Repository
{
    public class DetalhesRepository : BaseRepository, IDetalhesRepositoy
    {
        public DetalhesRepository(IDatabaseConnection connection) : base(connection)
        {
        }
        private enum Procedures
        {
            DetalheVendaCliente
        }

        public DetalhesDto ListarPorid(int idVenda)
        {
             ExecuteProcedure(Procedures.DetalheVendaCliente);
            AddParameter("@IdVenda", idVenda);

            using (var r = ExecuteReader())
            {
                return r.CastEnumerable<DetalhesDto>().FirstOrDefault();
            }
        }
    }
}
