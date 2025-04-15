using System.Collections.Generic;
using Concessionaria.Repository.Infra;
using Concessionaria.Domain.Modelo;
using Concessionaria.Repository.Infra.Extensions;
using System.Linq;
using Concessionaria.Domain.Carroceria.Dto;
using Concessionaria.Domain.Modelo.Dto;
using Concessionaria.Domain.Marca.Dto;
using Concessionaria.Domain.Motorizacao.Dto;

namespace Concessionaria.Repository
{
    public class ModeloRepository : BaseRepository, IModeloRepository
    {
        public ModeloRepository(IDatabaseConnection connection) : base(connection)
        {
        }
       
        private enum Procedures
        {
            ListarTodosModelos,
            ListarModeloPorId,
            AdicionarModelo,
            AtualizarModelo,
            ListarModelos2,
            ModeloTeste,
            DeletarModelo,
            VerificarModeloEmEstoque
        }
   
        public IEnumerable<ModeloDto> ListarTodosModelos()
        {
            ExecuteProcedure(Procedures.ListarTodosModelos);

            var modelos = new List<ModeloDto>(); 

            using (var r = ExecuteReader())
            {
                while (r.Read())
                {
                    
                    var modelo = r.Cast<ModeloDto>();

                    modelo.Modelo = r.ReadAttr<string>("NomeModelo");


                    modelo.Marca = new MarcaDto
                    {
                        Marca = r.ReadAttr<string>("NomeMarca")
                    };

                    modelo.Potencia = new MotorizacaoDto
                    {
                        Potencia = r.ReadAttr<string>("NomeMotorizacao")
                    };

                    modelo.Tipo = new TipoCarroceriaDto
                    {
                        Tipo = r.ReadAttr<string>("NomeCarroceria")
                    };

                    modelos.Add(modelo); 
                }
            }

            return modelos; 
        }
        public ModeloDto ListarPorid(int id)
        {
            ExecuteProcedure(Procedures.ListarModeloPorId);

            AddParameter("@IdModelo", id);

            using (var r = ExecuteReader())
            {
                if (r.Read())
                {
                    var modelo = r.Cast<ModeloDto>();

                    modelo.Modelo = r.ReadAttr<string>("NomeModelo");

                    modelo.Marca = new MarcaDto
                    {
                        IdMarca = r.ReadAttr<int>("IdMarca"),  // Lê o Id da Marca
                        Marca = r.ReadAttr<string>("NomeMarca")  // Lê o nome da Marca
                    };

                    modelo.Potencia = new MotorizacaoDto
                    {
                        IdMotorizacao = r.ReadAttr<int>("IdMotorizacao"),  // Lê o Id da Motorização
                        Potencia = r.ReadAttr<string>("NomeMotorizacao")  // Lê o nome da Motorização
                    };

                    modelo.Tipo = new TipoCarroceriaDto
                    {
                        IdTipoCarroceria = r.ReadAttr<int>("IdTipoCarroceria"),  // Lê o Id do Tipo de Carroceria
                        Tipo = r.ReadAttr<string>("NomeCarroceria")  // Lê o nome do Tipo de Carroceria
                    };

                    return modelo;
                }
            }

            return null;
        }

        public int Post(ModeloDto modelo)
        {
            ExecuteProcedure(Procedures.AdicionarModelo);

            AddParameter("@modelo", modelo.Modelo);
            AddParameter("@IdMarca", modelo.Marca.IdMarca);
            AddParameter("@IdMotorizacao", modelo.Potencia.IdMotorizacao);
            AddParameter("@IdTipoCarroceria", modelo.Tipo.IdTipoCarroceria);
            AddParameter("@AnoMinimo", modelo.AnoMinimo);
            AddParameter("@AnoMaximo", modelo.AnoMaximo);
            return ExecuteNonQueryWithReturn<int>(); 
        }

        public void Put(ModeloDto modelo)
        {
            ExecuteProcedure(Procedures.AtualizarModelo);
            AddParameter("@IdModelo", modelo.IdModelo);
             AddParameter("@IdMarca", modelo.Marca.IdMarca);
            AddParameter("@Modelo", modelo.Modelo);
            AddParameter("@IdMotorizacao", modelo.Potencia.IdMotorizacao);
            AddParameter("@IdTipoCarroceria", modelo.Tipo.IdTipoCarroceria);
            AddParameter("@AnoMinimo", modelo.AnoMinimo);
            AddParameter("@AnoMaximo", modelo.AnoMaximo);
            ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            ExecuteProcedure(Procedures.DeletarModelo);
            AddParameter("@IdModelo", id);
            ExecuteNonQuery(); 
        }

        public IEnumerable<ModeloDto> ListarAllModelosOrName()
        {
            ExecuteProcedure(Procedures.ListarModelos2);

            var modelos = new List<ModeloDto>();

            using (var r = ExecuteReader())
            {
                while (r.Read())
                {
                    var modelo = r.Cast<ModeloDto>();

                    modelo.Modelo = r.ReadAttr<string>("NomeModelo");

                    modelo.Potencia = new MotorizacaoDto
                    {
                        Potencia = r.ReadAttr<string>("NomeMotorizacao")
                    };

                    modelo.Tipo = new TipoCarroceriaDto
                    {
                        Tipo = r.ReadAttr<string>("NomeCarroceria")
                    };

                    modelos.Add(modelo); // Add the modelo to the list
                }
            }

            return modelos; // Return the complete list of modelos
        }

        public int ValidarModeloEstoque(int id)
        {
            ExecuteProcedure(Procedures.VerificarModeloEmEstoque);
            AddParameter("@IdModelo", id);
            int validacao = ExecuteNonQueryWithReturn<int>();
            return validacao;
        }

    }
}


