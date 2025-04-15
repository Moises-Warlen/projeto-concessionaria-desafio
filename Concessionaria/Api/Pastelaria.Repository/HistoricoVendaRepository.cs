using Concessionaria.Domain.Venda;
using Concessionaria.Domain.Venda.Dto;
using Concessionaria.Repository.Infra;
using System;
using System.Collections.Generic;


namespace Concessionaria.Repository
{
    public class HistoricoVendaRepository : BaseRepository, IHistoricoVendaRepository
    {
        public HistoricoVendaRepository(IDatabaseConnection connection) : base(connection)
        {
        }
        private enum Procedures
        {
            ListarVendas,
        }
        public IEnumerable<HistoricoVendaDto> ListarTodasVendas()
        {
            ExecuteProcedure(Procedures.ListarVendas);
            using (var r = ExecuteReader())
            {
                var historicoVendas = new List<HistoricoVendaDto>();
                while (r.Read())
                {
                    var venda = new HistoricoVendaDto
                    {
                        IdVenda = Convert.ToInt32(r["IdVenda"]),       // Mapeamento do IdVenda
                        IdCiente = Convert.ToInt32(r["IdCliente"]),
                        Cliente = r["NomeCliente"].ToString(),
                        Modelo = r["Modelo"].ToString(),
                        Tipo = r["TipoCarroceria"].ToString(),
                        Potencia = r["Motorizacao"].ToString(),
                        DataVenda = Convert.ToDateTime(r["DataVenda"])
                    };
                    historicoVendas.Add(venda);
                }
                return historicoVendas;
            }
        }

    }
}
