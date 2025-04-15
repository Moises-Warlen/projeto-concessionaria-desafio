using System;
using System.Collections.Generic;
using Concessionaria.Domain.Cliente;
using Concessionaria.Domain.Cliente.Dto;
using Concessionaria.Repository.Infra;
using Concessionaria.Repository.Infra.Extensions;
using System.Linq;

namespace Concessionaria.Repository
{
    public class ClienteRepository : BaseRepository, IClienteRepository
    {
        public ClienteRepository(IDatabaseConnection connection) : base(connection)
        {

        }
        private enum Procedures
        {
            AdicionarCliente,
            ListartodosCiente,
            DesativarCliente,
            AtualizarCliente,
            BuscarClientePorCPF
        }
        public IEnumerable<ClienteDto> Get()
        {
            ExecuteProcedure(Procedures.ListartodosCiente);
            using (var r = ExecuteReader())
                return r.CastEnumerable<ClienteDto>();
        }

        public ClienteDto GetId(int id)
        {
            ExecuteProcedure(Procedures.ListartodosCiente);
            AddParameter("IdCliente", id);
            using (var r = ExecuteReader())
            {
                return r.CastEnumerable<ClienteDto>().FirstOrDefault();
            }
        }

        public int Post(ClienteDto cliente)
        {
            ExecuteProcedure(Procedures.AdicionarCliente);

                AddParameter("@Nome", cliente.Nome);
                AddParameter("@CPF", cliente.CPF);
                AddParameter("@DataNascimento",cliente.DataNascimento);
                AddParameter("@Ativo", true);

            return ExecuteNonQueryWithReturn<int>();  // Executa o comando e retorna o Id do novo Cliente

        }
        public ClienteDto PutDesativaCliente(int IdCliente)
        {

            ExecuteProcedure(Procedures.DesativarCliente);
            AddParameter("@idCliente", IdCliente);
            using (var r = ExecuteReader())
                return r.Read() ? r.Cast<ClienteDto>() : null;
        }

        public void Put(ClienteDto cliente)
        {
            ExecuteProcedure(Procedures.AtualizarCliente);  
            
            AddParameter("@IdCliente", cliente.IdCliente);
            AddParameter("@Nome", cliente.Nome);
            AddParameter("@CPF", cliente.CPF);
            AddParameter("@DataNascimento", cliente.DataNascimento);
            

            ExecuteNonQuery();
        }

        public void Delete(int Idcliente)
        {
            throw new NotImplementedException();
        }

        public ClienteDto GetCpf(string cpf)
        {
            ExecuteProcedure(Procedures.BuscarClientePorCPF);
            AddParameter("@CPF", cpf);
            using (var r = ExecuteReader())
            {
                return r.CastEnumerable<ClienteDto>().FirstOrDefault();
            }
        }

    }
}
