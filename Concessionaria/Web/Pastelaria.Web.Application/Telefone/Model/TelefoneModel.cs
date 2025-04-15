
namespace Concessionaria.Web.Application.Telefone.Model
{
    public  class TelefoneModel
    {
        public int IdTelefone { get; set; }
        public string DDD { get; set; }
        public string Numero { get; set; }
        public string Tipo { get; set; }
        public int IdCliente { get; set; }
    }
}
