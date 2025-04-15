using Concessionaria.Api.Infra.Configuration;
using Concessionaria.Domain.Cliente;
using Concessionaria.Domain.Cliente.Dto;
using Concessionaria.Domain.Email;
using Concessionaria.Domain.Endereco;
using Concessionaria.Domain.Telefone;
using System.Web.Http;

namespace Concessionaria.Api.Controllers
{
    [RoutePrefix("api/cliente")]
    public class ClienteController : AuthApiController
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IEnderecoRepository _enderecoRepository;
        private readonly IEmailRepository _emailRepository;
        private readonly ITelefoneRepository _telefoneRepository;

        public ClienteController(IClienteRepository clienteRepository , IEnderecoRepository enderecoRepository , IEmailRepository emailRepository , ITelefoneRepository telefoneRepository)
        {
            _clienteRepository = clienteRepository;
            _enderecoRepository = enderecoRepository;
            _emailRepository = emailRepository;
            _telefoneRepository = telefoneRepository;
        }



        [HttpGet, Route("todos")]
        public IHttpActionResult Get()
        {
            var clientes = _clienteRepository.Get();
            return Ok(clientes);
        }

        [HttpGet, Route("{id:int}")]
        public IHttpActionResult GetId(int id)
        {
            var cliente = _clienteRepository.GetId(id);
            return Ok(cliente);
        }


        public IHttpActionResult Post(ClienteDto cliente)
        {
            if (cliente.IdCliente > 0)
                return Put(cliente);

            var idCliente = _clienteRepository.Post(cliente);

            foreach (var email in cliente.Email)
                _emailRepository.Post(idCliente, email);

            foreach (var endereco in cliente.Endereco)
                _enderecoRepository.Post(idCliente, endereco);

            foreach (var telefone in cliente.Telefones)
                _telefoneRepository.Post(idCliente, telefone);

            return Ok();
        }
        // Método privado para atualizar um cliente existente.
        private IHttpActionResult Put(ClienteDto cliente)
        {
            _clienteRepository.Put(cliente);

           _enderecoRepository.Delete(cliente.IdCliente);
            foreach (var endereco in cliente.Endereco)
                _enderecoRepository.Post(cliente.IdCliente, endereco);

            _emailRepository.Delete(cliente.IdCliente);
            foreach (var email in cliente.Email)
                _emailRepository.Post(cliente.IdCliente, email);


            _telefoneRepository.Delete(cliente.IdCliente);
            foreach (var telefone in cliente.Telefones)
                _telefoneRepository.Post(cliente.IdCliente, telefone);

            return Ok();
        }



        // Endpoint para Desativar uma cliente baseado no Id
        [HttpDelete, Route("{id}")]
        public IHttpActionResult Delete(int id)
        {
            _clienteRepository.PutDesativaCliente(id); // desativar com Id fornecido

            return Ok(); // Retorna um código de status HTTP 200 (OK) indicando que a operação foi bem-sucedida.
        }



        [HttpGet, Route("cpf/{cpf}")]
        public IHttpActionResult GetByCPF(string cpf)
        {
            var cliente = _clienteRepository.GetCpf(cpf);
            if (cliente == null)
            {
                return NotFound();
            }
            return Ok(cliente);
        }

    }
}