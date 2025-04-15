

using Concessionaria.Web.Application.Email.Model;
using Concessionaria.Web.Application.Endereco.Model;
using Concessionaria.Web.Application.Telefone.Model;
using System;
using System.Collections.Generic;

namespace Concessionaria.Web.Application.Cliente.Model
{
    public class ClienteModel
    {
        public int IdCliente { get; set; }
        public string CPF { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public bool Ativo { get; set; }
        public IEnumerable<TelefoneModel> Telefones { get; set; }
        public IEnumerable<EnderecoModel> Endereco { get; set; }
        public IEnumerable<EmailModel> Email { get; set; }
    }
}
