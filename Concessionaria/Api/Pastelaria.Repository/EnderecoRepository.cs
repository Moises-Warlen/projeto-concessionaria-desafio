
using System;
using System.Collections.Generic;
using Concessionaria.Domain.Endereco;
using Concessionaria.Domain.Endereco.Dto;
using Concessionaria.Repository.Infra;
using Concessionaria.Repository.Infra.Extensions;

namespace Concessionaria.Repository
{
    public class EnderecoRepository : BaseRepository, IEnderecoRepository
    {
        public EnderecoRepository(IDatabaseConnection connection) : base(connection)
        {
        }

        private enum Procedures
        {
            AdicionarEnderecoCliente, //  procedure para adicionar um endereço a um cliente
            ListarTodosEndereco,
            DeletarenderecoCliente,
        }

        public IEnumerable<EnderecoDto> Get()
        {
            ExecuteProcedure(Procedures.ListarTodosEndereco);
            using (var r = ExecuteReader())
                return r.CastEnumerable<EnderecoDto>();

        }
        public IEnumerable<EnderecoDto> GetId(int id)
        {
            ExecuteProcedure(Procedures.ListarTodosEndereco);
            AddParameter("@IdCliente", id);
            using (var r = ExecuteReader())
                return r.CastEnumerable<EnderecoDto>();
        }

        public void Post(int idCliente, EnderecoDto endereco)
        {
            ExecuteProcedure(Procedures.AdicionarEnderecoCliente);

                AddParameter("@IdCliente", idCliente);
                AddParameter("@CEP", endereco.CEP);
                AddParameter("@Rua", endereco.Rua);
                AddParameter("@Numero", endereco.Numero);
                AddParameter("@Bairro", endereco.Bairro);
                AddParameter("@Cidade", endereco.Cidade);
                AddParameter("@Tipo", endereco.Tipo);

            ExecuteNonQuery();
        }
        public void DeleteEnderecoCliente(int id)
        {
            ExecuteProcedure(Procedures.DeletarenderecoCliente);
            AddParameter("IdCliente", id);
            ExecuteNonQuery();


        }

        public void Delete(int id)
        {
            ExecuteProcedure(Procedures.DeletarenderecoCliente);
            AddParameter("IdCliente", id);
            ExecuteNonQuery();

        }

    }
}
