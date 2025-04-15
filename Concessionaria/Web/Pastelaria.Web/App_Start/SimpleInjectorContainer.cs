using Concessionaria.Web.Application.Teste;
using SimpleInjector;

namespace Concessionaria.Web
{
    public static class SimpleInjectorContainer
    {
        public static Container RegisterServices()
        {

            var container = new Container();

            container.Register<TesteApplication>();

            container.Verify();

            return container;
        }
    }
}