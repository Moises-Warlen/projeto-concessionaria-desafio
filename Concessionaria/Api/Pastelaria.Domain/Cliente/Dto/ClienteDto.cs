
using Concessionaria.Domain.Email.Dto;
using Concessionaria.Domain.Endereco.Dto;
using Concessionaria.Domain.Telefone.Dto;
using System;
using System.Collections.Generic;

namespace Concessionaria.Domain.Cliente.Dto
{
    public class ClienteDto
    {
        public int IdCliente { get; set; }
        public string CPF { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public bool Ativo { get; set; }
        public List<TelefoneDto> Telefones { get; set; } 
        public List<EnderecoDto> Endereco { get; set; }
        public List<EmailDto> Email { get; set; }

    }
}
