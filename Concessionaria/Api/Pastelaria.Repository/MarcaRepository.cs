using System.Collections.Generic;
using Concessionaria.Repository.Infra;
using Concessionaria.Domain.Marca;
using Concessionaria.Repository.Infra.Extensions;
using System.Linq;
using Concessionaria.Domain.Marca.Dto;
using System;

namespace Concessionaria.Repository
{
    public class MarcaRepository : BaseRepository, IMarcaRepository
    {
        public MarcaRepository(IDatabaseConnection connection) : base(connection)
        {
        }

        private enum Procedures
        {
            ListarTodasMarcas,
            AdicionarMarca,
            AtualizarMarca,
            DeletarMarca,
            ListarMarcaPorId,
            VerificarMarcaAssociadaAModelos,
        }
     
        public IEnumerable<MarcaDto> ListarTodasMarcas()
        {
            ExecuteProcedure(Procedures.ListarTodasMarcas);

            using (var r = ExecuteReader())
                return r.CastEnumerable<MarcaDto>();
        }
        public MarcaDto ListarPorid(int id)
        {
            ExecuteProcedure(Procedures.ListarMarcaPorId);
            AddParameter("@IdMarca", id);

            using (var r = ExecuteReader())
            {
                return r.CastEnumerable<MarcaDto>().FirstOrDefault();
            }
        }

        public int Post(MarcaDto marca)
        {
            ExecuteProcedure(Procedures.AdicionarMarca); 
            AddParameter("@Marca", marca.Marca);
            return ExecuteNonQueryWithReturn<int>();  
        }
        public void Put(MarcaDto marca)
        {
            ExecuteProcedure(Procedures.AtualizarMarca);
            AddParameter("@IdMarca", marca.IdMarca);
            AddParameter("@Marca", marca.Marca);
            ExecuteNonQuery(); 
        }
        public void Delete(int id)
        {
            ExecuteProcedure(Procedures.DeletarMarca);
            AddParameter("@IdMarca", id);
            ExecuteNonQuery();  
        }

        public int ValidarMarcaEmodelo(int id)
        {
            ExecuteProcedure(Procedures.VerificarMarcaAssociadaAModelos);
            AddParameter("@IdMarca", id);
            int validacao = ExecuteNonQueryWithReturn<int>();
            return validacao;
        }
    }
}



