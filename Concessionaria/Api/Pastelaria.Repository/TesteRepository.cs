using Concessionaria.Domain.Teste;
using Concessionaria.Domain.Teste.Dto;
using Concessionaria.Repository.Infra;
using Concessionaria.Repository.Infra.Extensions;
using System.Collections.Generic;

namespace Concessionaria.Repository
{
    public class TesteRepository : BaseRepository, ITesteRepository
    {
        public TesteRepository(IDatabaseConnection connection) : base(connection)
        {
        }

        private enum Procedures
        {
            GKSSP_SelDescricao,
            GKSSP_InsTeste
        }


        public IEnumerable<TesteDto> Get()
        {
            ExecuteProcedure(Procedures.GKSSP_SelDescricao);

            using (var r = ExecuteReader())
                return r.CastEnumerable<TesteDto>();
        }

        public void Post(TesteDto teste)
        {
            ExecuteProcedure(Procedures.GKSSP_InsTeste);
            AddParameter("@Num_SeqlNegativ", teste.Id);
            AddParameter("@Num_ChavParc", teste.Id);
            ExecuteNonQuery();
        }
    }
}