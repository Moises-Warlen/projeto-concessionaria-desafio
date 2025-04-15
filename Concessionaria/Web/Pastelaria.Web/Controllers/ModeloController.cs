using Concessionaria.Web.Application.Marca;
using Concessionaria.Web.Application.Modelo;
using Concessionaria.Web.Application.Modelo.Model;
using Concessionaria.Web.Application.Motorizacao;
using Concessionaria.Web.Application.TipoCarroceria;
using Concessionaria.Web.Infra;
using System.Web.Mvc;

namespace Concessionaria.Web.Controllers
{
    public class ModeloController : BaseController
    {
        private readonly ModeloApplication _modeloApplication;
        private readonly MarcaApplication _marcaApplication;
        private readonly MotorizacaoApplication _motorizacaoApplication;
        private readonly TipoCarroceriaApplication _tipocarroceriaApplication;
        public ModeloController(ModeloApplication modeloApplication, MarcaApplication marcaApplication, MotorizacaoApplication motorizacaoApplication, TipoCarroceriaApplication tipocarroceriaApplication)
        {
            _modeloApplication = modeloApplication;
            _marcaApplication = marcaApplication;
            _motorizacaoApplication = motorizacaoApplication;
            _tipocarroceriaApplication = tipocarroceriaApplication;
        }

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ListarModelos()
        {
            var response = _modeloApplication.BuscarModelos();

            return View("_GridModelos", response.Content);
        }

        public ActionResult Adicionar()
        {
            var marcas = _marcaApplication.BuscarMarcas().Content;
            var motorizacoes = _motorizacaoApplication.BuscarTodasPotencias().Content;
            var tipos = _tipocarroceriaApplication.BuscarTiposCarroceria().Content;

            return View(new AdicionarModeloViewModel
            {
                Marcas = marcas,
                Motorizacoes = motorizacoes,
                TiposCarroceria = tipos
            });
        }

        [HttpPost]
        public ActionResult Adicionar(ModeloModel model)
        {
            if (ModelState.IsValid)
            {
                var response = _modeloApplication.Post(model);
                return Json(new { success = true, message = "Modelo adicionado com sucesso!" });
               
            }
            return Json(new { success = false, message = "Verifique os dados e preencher todos os campos" });
        }

        public ActionResult Editar(int id)
        {
            // Buscar o modelo pelo ID
            var modelo = _modeloApplication.BuscarModeloPorId(id).Content;
            if (modelo == null)
            {
                return HttpNotFound();
            }

            // Carregar as listas necessárias
            var marcas = _marcaApplication.BuscarMarcas().Content;
            var motorizacoes = _motorizacaoApplication.BuscarTodasPotencias().Content;
            var tipos = _tipocarroceriaApplication.BuscarTiposCarroceria().Content;

            // Retornar um ViewModel para a view
            var viewModel = new EditarModeloViewModel
            {
                Modelo = modelo,
                Marcas = marcas,
                Motorizacoes = motorizacoes,
                TiposCarroceria = tipos
            };

            return View(viewModel);
        }



        [HttpPost]
        public ActionResult Editar(ModeloModel model)
        {
            if (ModelState.IsValid)
            {
                var response = _modeloApplication.Put(model); // Método para atualizar
              
                {
                    return Json(new { success = true, message = "Modelo editado com sucesso!" });
                }
            }
            return Json(new { success = false, message = "Verifique os dados e preencher todos os campos" });
        }

        public ActionResult Excluir(int id)
        {

            // Valida se tem estoque está associada a algum modelo
            var validacaoResponse = _modeloApplication.ValidarModeloEstoque(id).Content;
            // Se o valor retornado for 0, significa que o modelo nao esta associado ao estoque

            if (validacaoResponse == false)
            {
                // Tenta excluir a marca
                var response = _modeloApplication.Delete(id); // Supondo que Delete retorne Response<bool>

                // Acessa o conteúdo da resposta para verificar o sucesso da exclusão
                bool sucesso = response.Ok;  // Acessa o valor real do sucesso (true ou false)

                if (sucesso)  // Se a exclusão foi bem-sucedida (true)
                {
                    return Json(new { success = true, message = "Modelo excluído com sucesso!" });
                }
                else
                {
                    return Json(new { success = false, message = "Falha ao excluir Modelo." });
                }
            }
            else
            {
                // Se a marca estiver associada a um modelo, não pode ser excluída
                return Json(new { success = false, message = "Não é possível excluir Modelo porque está associada a um Estoque." });
            }

        }

    }

}
