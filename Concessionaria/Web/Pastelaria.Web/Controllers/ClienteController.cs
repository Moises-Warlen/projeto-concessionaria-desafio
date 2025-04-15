using Concessionaria.Web.Application.Cliente;
using Concessionaria.Web.Application.Cliente.Model;
using Concessionaria.Web.Application.Email;
using Concessionaria.Web.Application.Email.Model;
using Concessionaria.Web.Application.Endereco;
using Concessionaria.Web.Application.Endereco.Model;
using Concessionaria.Web.Application.Telefone;
using Concessionaria.Web.Application.Telefone.Model;
using Concessionaria.Web.Infra;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Concessionaria.Web.Controllers
{
    public class ClienteController : BaseController
    {
        private readonly ClienteApplication _clienteApplication;
        private readonly TelefoneApplication _telefoneApplication;
        private readonly EnderecoApplication _enderecoApplication;
        private readonly EmailApplication _emailApplication;

        public ClienteController(ClienteApplication clienteApplication, TelefoneApplication telefoneApplication, EnderecoApplication enderecoApplication, EmailApplication emailApplication)
        {
            _clienteApplication = clienteApplication;
            _telefoneApplication = telefoneApplication;
            _enderecoApplication = enderecoApplication;
            _emailApplication = emailApplication;
        }

        // Exibe a tela principal de clientes
        public ActionResult Index()
        {
            return View();
        }

        // Método para buscar cliente por CPF e retornar a view de edição/adicionar com os dados 
        public ActionResult BuscarClientePorCPF(string cpf = null)
        {
            if (string.IsNullOrEmpty(cpf))
            {
                // Se não houver CPF, retornamos um novo cliente vazio
                return View("_Form", new ClienteModel
                {
                    Telefones = new List<TelefoneModel>(),
                    Endereco = new List<EnderecoModel>(),
                    Email = new List<EmailModel>()
                });
            }

            // Buscar os dados do cliente pelo CPF
            var clienteResponse = _clienteApplication.GetClientePorCPF(cpf);
            if (!clienteResponse.Ok)
            {
                return Error("Falha ao buscar o cliente.");
            }
            var cliente = clienteResponse.Content;

            var telefonesResponse = _telefoneApplication.GetTelefone(cliente.IdCliente);
            var enderecoResponse = _enderecoApplication.GetEndereco(cliente.IdCliente);
            var emailResponse = _emailApplication.GetEmail(cliente.IdCliente);

            if (!telefonesResponse.Ok || !enderecoResponse.Ok || !emailResponse.Ok)
            {
                return Error("Falha ao buscar dados relacionados ao cliente.");
            }

            // Preenche o modelo com os dados do cliente e suas informações relacionadas
            cliente.Telefones = telefonesResponse.Content;
            cliente.Endereco = enderecoResponse.Content;
            cliente.Email = emailResponse.Content;

            return View("_Form", cliente);
        }

        // Tela de edição ou adição de cliente
        public ActionResult BuscarTelaEditarCliente(int? id = null)
        {
            if (!id.HasValue)
            {
                // Se não houver ID, retornamos um novo cliente vazio
                return View("_Form", new ClienteModel
                {
                    Telefones = new List<TelefoneModel>(),
                    Endereco = new List<EnderecoModel>(),
                    Email = new List<EmailModel>()
                });
            }

            // Se houver ID, buscamos os dados do cliente
            var clienteResponse = _clienteApplication.GetCliente(id.Value);
            if (!clienteResponse.Ok)
            {
                return Error("Falha ao buscar o cliente.");
            }

            var cliente = clienteResponse.Content;


            // Buscando os telefones, endereços e e-mails do cliente
            var telefonesResponse = _telefoneApplication.GetTelefone(cliente.IdCliente);
            var enderecoResponse = _enderecoApplication.GetEndereco(cliente.IdCliente);
            var emailResponse = _emailApplication.GetEmail(cliente.IdCliente);

            if (!telefonesResponse.Ok || !enderecoResponse.Ok || !emailResponse.Ok)
            {
                return Error("Falha ao buscar dados relacionados ao cliente.");
            }

            // Preenche o modelo com os dados do cliente e suas informações relacionadas
            cliente.Telefones = telefonesResponse.Content;
            cliente.Endereco = enderecoResponse.Content;
            cliente.Email = emailResponse.Content;

            return View("_Form", cliente);
        }

        // Salva ou atualiza o cliente
        public ActionResult Post(ClienteModel cliente)
        {
            var dataMinima = "01/01/0001 00:00:00";

            if ( cliente.Nome == null || cliente.CPF == null || cliente.DataNascimento.ToString() == dataMinima || cliente.Email == null || cliente.Telefones == null || cliente.Endereco == null)
            {
                return Json(new { success = false, message = "Preencher todos os campos." });
            }

            var response = _clienteApplication.Post(cliente);
            if (!response.Ok)
            {
                return Error("Falha ao inserir/atualizar cliente.");
            }

            return Json(new { success = true });
        }


        // Lista todos os clientes
        public ActionResult ListarClientes()
        {
            var response = _clienteApplication.GetClientes();
            if (!response.Ok)
                return Error("Falha ao buscar os clientes.");

            return View("_GridClientes", response.Content);
        }

        // Desativa um cliente
        public ActionResult Desativar(int id)
        {
            _clienteApplication.Delete(id);
            return Success();

        }
    }
}
