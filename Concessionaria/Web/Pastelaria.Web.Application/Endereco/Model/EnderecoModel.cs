

namespace Concessionaria.Web.Application.Endereco.Model
{
    public class EnderecoModel
    {
        public int IdEndereco { get; set; }
        public string CEP { get; set; }
        public string Rua { get; set; }
        public int Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Tipo { get; set; }
        public int IdCliente { get; set; }
    }
}
