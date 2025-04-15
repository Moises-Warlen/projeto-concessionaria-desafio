using Concessionaria.Domain.Cliente;
using Concessionaria.Domain.Email;
using Concessionaria.Domain.Endereco;
using Concessionaria.Domain.Estoque;
using Concessionaria.Domain.Marca;
using Concessionaria.Domain.Modelo;
using Concessionaria.Domain.Motorizacao;
using Concessionaria.Domain.Telefone;
using Concessionaria.Domain.Teste;
using Concessionaria.Domain.TipoCarroceria;
using Concessionaria.Domain.Venda;
using Concessionaria.Repository;
using Concessionaria.Repository.Infra;
using SimpleInjector;
using SimpleInjector.Lifestyles;

namespace Concessionaria.Api
{
    public static class SimpleInjectorContainer
    {
        private static readonly Container Container = new Container();

        public static Container Build()
        {
            Container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            Container.Register<IDatabaseConnection, DatabaseConnection>(Lifestyle.Scoped);
            //Container.Register<Notification>(Lifestyle.Scoped);

            RegisterRepositories();

            Container.Verify();
            return Container;
        }

        private static void RegisterRepositories()
        {
            Container.Register<ITesteRepository, TesteRepository>();
            Container.Register<IMarcaRepository, MarcaRepository>();
            Container.Register<IModeloRepository, ModeloRepository>();
            Container.Register<ITipoCarroceriaRepository, TipoCarroceriaRepository>();
            Container.Register<IMotorizacaoRepository, MotorizacaoRepository>();
            Container.Register<IEstoqueRepository, EstoqueRepository>();
            Container.Register<IClienteRepository, ClienteRepository>();
            Container.Register<IEmailRepository, EmailRepository>();
            Container.Register<IEnderecoRepository, EnderecoRepository>();
            Container.Register<ITelefoneRepository, TelefoneRepository>();
            Container.Register<IHistoricoVendaRepository, HistoricoVendaRepository>();
            Container.Register<IDetalhesRepositoy, DetalhesRepository>();
            Container.Register<IVendaRepository, VendaRepository>();

        }
}
}