
using Concessionaria.Web.Application.Cliente;
using Concessionaria.Web.Application.DetalhesVendas;
using Concessionaria.Web.Application.Email;
using Concessionaria.Web.Application.Estoque;
using Concessionaria.Web.Application.HistoricoVendas;
using Concessionaria.Web.Application.Venda;
using Concessionaria.Web.Application.Venda.Model;
using Concessionaria.Web.Helper;
using Concessionaria.Web.Infra;
using System;
using System.Web.Mvc;

namespace Concessionaria.Web.Controllers
{
    public class VendaController : BaseController
    {
        private readonly ClienteApplication _clienteApplication;
        private readonly EstoqueApplication _estoqueApplication;
        private readonly HistoricoApplication _historicoApplication;
        private readonly DetalhesVendaApplication _detalhevendaApplication;
        private readonly VendaApplication _vendaApplication;
        private readonly EmailApplication _emailApplication;
        private readonly EmailService _emailService;


        public VendaController(EmailService emailService, EmailApplication emailApplication, ClienteApplication clienteApplication, EstoqueApplication estoqueApplication, HistoricoApplication historicoApplication , DetalhesVendaApplication detalhevendaApplication, VendaApplication vendaApplication)
        {
            _estoqueApplication = estoqueApplication;
            _clienteApplication = clienteApplication;
            _historicoApplication = historicoApplication;
            _detalhevendaApplication = detalhevendaApplication;
            _vendaApplication = vendaApplication;
            _emailApplication = emailApplication;
            _emailService = emailService;
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Adicionar()
        {
            var cliente = _clienteApplication.GetClientes().Content;
            var estoque = _estoqueApplication.BuscarEstoque().Content;
            return View(new AdicionarVendaViewModel
            {
                Clientes = cliente,
                Estoques = estoque,
            });
        }
        public ActionResult ListaVendas()
        {
            var response = _historicoApplication.BuscarHistoricoVendas();

            return View("_GridVendas",response.Content);
        }
        public ActionResult DetalhesVendas(int idVenda)
        {
            var response = _detalhevendaApplication.BuscarDetalhesPorId(idVenda);

            // Se não encontrar os detalhes da venda, redireciona ou exibe uma mensagem de erro
            if (response.Content == null)
            {
                return HttpNotFound();
            }

            return View("DetalhesVendas", response.Content);
        }

        [HttpPost]
        public ActionResult Post(VendaModel venda)
        {
            if (ModelState.IsValid)
            {
                var response = _vendaApplication.Post(venda);
                var idCliente = venda.Cliente.IdCliente;
                var emailCliente = _emailApplication.GetEmail(idCliente).Content;
                // Verifique se o cliente não é nulo e se há emails associados
                if (venda.Cliente != null && emailCliente != null)
                {
                    // Percorra todos os emails do cliente e envie os emails
                    foreach (var email in emailCliente)
                    {
                        try
                        {
                            // Envie o email usando EmailApplication
                            _emailService.EnviarEmail(email.Email, "Assunto do Email", "Corpo do Email");
                        }
                        catch (Exception ex)
                        {
                            // Registra o erro específico para cada e-mail falhado, se necessário.
                            Console.WriteLine($"Erro ao enviar e-mail para {email.Email}: {ex.Message}");
                        }
                    }
                }

                return Json(new { success = true, message = "Venda concluída com sucesso e emails enviados!" });
            }

            return Json(new { success = false, message = "Falha ao concluir venda" });
        }


    }
}