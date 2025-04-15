using System.Collections.Generic;
using Concessionaria.Domain.Estoque.Dto;
using Concessionaria.Repository.Infra;
using Concessionaria.Repository.Infra.Extensions;
using Concessionaria.Domain.Carroceria.Dto;
using Concessionaria.Domain.Estoque;
using System;
using Concessionaria.Domain.Modelo.Dto;
using Concessionaria.Domain.Motorizacao.Dto;


namespace Concessionaria.Repository
{
    public class EstoqueRepository : BaseRepository, IEstoqueRepository
    {
        public EstoqueRepository(IDatabaseConnection connection) : base(connection)
        {
        }
        private enum Procedures
        {
            ListarTodoEstoque,
            ListarTodoEstoque2,
            ListarEstoquePorId,
            AdicionarEstoque,
            DeletarEstoque,
            AtualizarEstoque,
            


        }
        public IEnumerable<EstoqueDto> ListarEstoques()
        {

            ExecuteProcedure(Procedures.ListarTodoEstoque);
            var estoques = new List<EstoqueDto>();
            using (var r = ExecuteReader())
            {
                while (r.Read())
                {
                    var estoque = r.Cast<EstoqueDto>();

                    estoque.Modelo = new ModeloDto
                    {
                        Modelo = r.ReadAttr<string>("NomeModelo")
                    };

                    estoque.Potencia = new MotorizacaoDto
                    {
                        Potencia = r.ReadAttr<string>("NomePotencia")
                    };

                    estoque.Tipo = new TipoCarroceriaDto
                    {
                        Tipo = r.ReadAttr<string>("NomeCarroceria")
                    };

                    estoques.Add(estoque);
                }
            }

            return estoques;
        }

      

        public int Post(EstoqueDto estoque)
        {
            ExecuteProcedure(Procedures.AdicionarEstoque);

            AddParameter("@Idmodelo", estoque.Modelo.IdModelo);
            AddParameter("@Ano", estoque.Ano);
            AddParameter("@MotorTurbo", estoque.MotorTurbo);
            AddParameter("@Detalhes", estoque.Detalhes);
            AddParameter("@Cor", estoque.Cor);
            AddParameter("@Valor", estoque.Valor);
            AddParameter("@Disponivel", estoque.Disponivel);
            AddParameter("@Placa", estoque.Placa);
            return ExecuteNonQueryWithReturn<int>();
        }

        public void Put(EstoqueDto estoque)
        {
            ExecuteProcedure(Procedures.AtualizarEstoque);
            AddParameter("@IdEstoque", estoque.IdEstoque);
            AddParameter("@Cor", estoque.Cor);
            AddParameter("@Placa", estoque.Placa);
            AddParameter("@MotorTurbo", estoque.MotorTurbo);
            AddParameter("@Detalhes", estoque.Detalhes);
            AddParameter("@Valor", estoque.Valor);
            ExecuteNonQuery();
        }

        public void Vendido(EstoqueDto estoque)
        {
            throw new NotImplementedException();
        }

        public EstoqueDto ListarEstoquePorId(int id)
        {
            ExecuteProcedure(Procedures.ListarEstoquePorId);

            // Adiciona o parâmetro com o ID do estoque que está sendo buscado
            AddParameter("@IdEstoqueCarro", id);

            EstoqueDto estoque = null;

            // Executa a leitura dos dados do estoque
            using (var r = ExecuteReader())
            {
                // Verifica se há pelo menos uma linha de dados
                if (r.Read())  // Se tiver dados
                {
                    // Mapeia o resultado da leitura para o DTO EstoqueDto
                    estoque = r.Cast<EstoqueDto>();

                    // Preenche os dados relacionados ao Modelo
                    estoque.Modelo = new ModeloDto
                    {
                        Modelo = r.ReadAttr<string>("NomeModelo")
                    };

                    // Preenche os dados de Potência
                    estoque.Potencia = new MotorizacaoDto
                    {
                        Potencia = r.ReadAttr<string>("NomePotencia")
                    };

                    // Preenche os dados de Tipo de Carroceria
                    estoque.Tipo = new TipoCarroceriaDto
                    {
                        Tipo = r.ReadAttr<string>("NomeCarroceria")
                    };
                }
                else
                {
                    // Se não houver dados, retorna null ou lança uma exceção específica
                    estoque = null;
                }
            }

            return estoque;
        }

        public void Delete(int id)
        {
            ExecuteProcedure(Procedures.DeletarEstoque);
            AddParameter("@IdEstoque", id);
            ExecuteNonQuery();
        }
    }
}

