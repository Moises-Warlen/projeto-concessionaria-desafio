
using System.Collections.Generic;
using Concessionaria.Domain.Motorizacao;
using Concessionaria.Repository.Infra;
using Concessionaria.Repository.Infra.Extensions;
using System.Linq;
using Concessionaria.Domain.Motorizacao.Dto;

namespace Concessionaria.Repository
{
    public class MotorizacaoRepository : BaseRepository, IMotorizacaoRepository
    {
        public MotorizacaoRepository(IDatabaseConnection connection) : base(connection)
        {
        }

        private enum Procedures
        {
            ListarTodasPotencia,
            ListarPotenciaPorId

        }
        public IEnumerable<MotorizacaoDto> ListarTodasPotencias()
        {
            ExecuteProcedure(Procedures.ListarTodasPotencia);

            using (var r = ExecuteReader())
                return r.CastEnumerable<MotorizacaoDto>();
        }

        public MotorizacaoDto ListarPorid(int id)
        {
            ExecuteProcedure(Procedures.ListarPotenciaPorId);
            AddParameter("@IdMotorizacao", id);

            using (var r = ExecuteReader())
            {
                return r.CastEnumerable<MotorizacaoDto>().FirstOrDefault();
            }
        }
    }
}
