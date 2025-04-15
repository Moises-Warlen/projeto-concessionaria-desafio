using System.Linq;

namespace Concessionaria.Repository.Infra
{
    public class Parameter
    {
        /// <summary/>
        /// <param name="name">Nome do parametro pode ser passado com ou sem '@' no inicio</param>
        /// <param name="value">Nao necessita de nenhum cast</param>
        public Parameter(string name, object value)
        {
            _name = name;
            Value = value;
        }

        private readonly string _name;

        public string Name => $"{(_name.FirstOrDefault() == '@' ? "" : "@")}{_name}";
        public object Value { get; }
    }
}