
using Concessionaria.Web.Application.Estoque;
using Concessionaria.Web.Application.Estoque.Model;
using Concessionaria.Web.Application.Modelo;
using Concessionaria.Web.Infra;
using System.Web.Mvc;

namespace Concessionaria.Web.Controllers
{ 
    public class EstoqueController : BaseController
    {

        private readonly EstoqueApplication _estoqueApplication;
        private readonly ModeloApplication _modeloApplication;

        public EstoqueController(EstoqueApplication estoqueApplication, ModeloApplication modeloApplication)
        {
            _estoqueApplication = estoqueApplication;
            _modeloApplication = modeloApplication;
        }


    public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListarEstoque()
        {

            var response = _estoqueApplication.BuscarEstoque();
            return View("_GridEstoques", response.Content);
        }

      
        public ActionResult Adicionar()
        {
            var modelos = _modeloApplication.BuscarModelos().Content;

            return View(new AdicionaEstoqueViewModel
            {
                Modelo = modelos
            });
        }

        [HttpPost]
        public ActionResult Adicionar(EstoqueModel model)
        {
            if (!ModelState.IsValid || model == null)
                return Json(new { success = false, message = "Falha ao adicionar ." });

            _estoqueApplication.Post(model);
            return Json(new { success = true, message = " adicionado com sucesso!" });
        }


        public ActionResult Editar(int id)
        {
            var estoque = _estoqueApplication.BuscarEstoquePorId(id).Content;

            return View("Editar", estoque);
        }

        [HttpPost]
        public ActionResult Editar(EstoqueModel model)
        {
            if (model.Cor == null || model.Placa == null || model.Valor == null || model.Detalhes == null)
                return Json(new { success = false, message = "Falha ao Editar preencher todos os campos." });

            var response = _estoqueApplication.Put(model);

            return Json(new { success = true, message = "Editado com sucesso!" });
        }




        public ActionResult Excluir(int id)
        {
            _estoqueApplication.Delete(id);
            return Json(new { success = true, message = "Modelo excluída com sucesso!" });
        }



        public ActionResult Detalhes()
        {
            return View();
        }

    }
}