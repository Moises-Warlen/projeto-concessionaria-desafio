
using System;
using System.Collections.Generic;
using Concessionaria.Domain.Email;
using Concessionaria.Domain.Email.Dto;
using Concessionaria.Repository.Infra;
using Concessionaria.Repository.Infra.Extensions;

namespace Concessionaria.Repository
{
    public class EmailRepository : BaseRepository, IEmailRepository 
    {
        public EmailRepository(IDatabaseConnection connection) : base(connection)
        {
        }
        public enum Procedures
        {
            AdicionarEmail,
            ListarTodosEmail,
            DeletarEmailCliente,
        }
        public IEnumerable<EmailDto> Get()
        {
            ExecuteProcedure(Procedures.ListarTodosEmail);
            using (var r = ExecuteReader()) // Executa a leitura da resposta da stored procedure.
                return r.CastEnumerable<EmailDto>();
        }
        public IEnumerable<EmailDto> GetId(int id)
        {
            ExecuteProcedure(Procedures.ListarTodosEmail);

            AddParameter("@IdCliente", id);
            using (var r = ExecuteReader())
                return r.CastEnumerable<EmailDto>();
        }
        public void Post(int idCliente, EmailDto email)
        {
            ExecuteProcedure(Procedures.AdicionarEmail);
            AddParameter("@IdCliente", idCliente);
            AddParameter("Email", email.Email);
            ExecuteNonQuery();
        }

        public void DeleteEmailCliente(int id)
        {
            ExecuteProcedure(Procedures.DeletarEmailCliente);
            AddParameter("@IdCliente", id);
            ExecuteNonQuery(); ;

        }
        public void Delete(int id)
        {
            ExecuteProcedure(Procedures.DeletarEmailCliente);
            AddParameter("@IdCliente", id);
            ExecuteNonQuery();
            
        }

    }
}
