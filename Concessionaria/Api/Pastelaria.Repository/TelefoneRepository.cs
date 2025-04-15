
using System;
using System.Collections.Generic;
using Concessionaria.Domain.Telefone;
using Concessionaria.Domain.Telefone.Dto;
using Concessionaria.Repository.Infra;
using Concessionaria.Repository.Infra.Extensions;

namespace Concessionaria.Repository
{
    public class TelefoneRepository : BaseRepository, ITelefoneRepository

    {
        public TelefoneRepository(IDatabaseConnection connection) : base(connection)
        {
        }

        private enum Procedures
        {
            AdicionarTelefone,
            ListarTodosTelefone,
            DeletarTelefoneCliente,
        }
        public IEnumerable<TelefoneDto> Get()
        {
            ExecuteProcedure(Procedures.ListarTodosTelefone);
            using (var r = ExecuteReader())
                return r.CastEnumerable<TelefoneDto>();

        }
        public void Post(int IdCliente ,TelefoneDto telefone)
        {
            ExecuteProcedure(Procedures.AdicionarTelefone);
            AddParameter("IdCliente" , IdCliente);
            AddParameter("DDD", telefone.DDD);
            AddParameter("Numero", telefone.Numero);
            AddParameter("Tipo", telefone.Tipo);

            ExecuteNonQuery();
        }


        public IEnumerable<TelefoneDto> Get(int? id = default(int?), string nome = null)
        {

            ExecuteProcedure(Procedures.ListarTodosTelefone);
            AddParameter("@IdCliente", id);
            using (var r = ExecuteReader())
                return r.CastEnumerable<TelefoneDto>();
        }
        public void DeletePorCliente(int id)
        {
            ExecuteProcedure(Procedures.DeletarTelefoneCliente);
            AddParameter("@IdCLiente", id);
            ExecuteNonQuery();


        }
        public void Delete(int id)
        {
            ExecuteProcedure(Procedures.DeletarTelefoneCliente);
            AddParameter("@IdCLiente", id);
            ExecuteNonQuery();
        }

       
    }
}
