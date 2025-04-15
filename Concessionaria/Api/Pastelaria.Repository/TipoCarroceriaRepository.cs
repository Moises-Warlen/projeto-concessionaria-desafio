
using Concessionaria.Repository.Infra;
using Concessionaria.Domain.TipoCarroceria;
using Concessionaria.Domain.Carroceria.Dto;
using System.Collections.Generic;
using Concessionaria.Repository.Infra.Extensions;
using System.Linq;

namespace Concessionaria.Repository
{
    public class TipoCarroceriaRepository : BaseRepository, ITipoCarroceriaRepository

    {
        public TipoCarroceriaRepository(IDatabaseConnection connection) : base(connection)
        {
        }
        private enum Procedures
        {
            ListarTodasCarrocerias,
            ListarCarroceriaPorId

        }

        public IEnumerable<TipoCarroceriaDto> ListasTiposCarroceria()
        {
            ExecuteProcedure(Procedures.ListarTodasCarrocerias);

            using (var r = ExecuteReader())
                return r.CastEnumerable<TipoCarroceriaDto>();
        }

        public TipoCarroceriaDto ListarPorid(int id)
        {
            ExecuteProcedure(Procedures.ListarCarroceriaPorId
);
            AddParameter("@IdTipoCarroceria", id);

            using (var r = ExecuteReader())
            {
                return r.CastEnumerable<TipoCarroceriaDto>().FirstOrDefault();
            }
        }
    }
}
