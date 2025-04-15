using Concessionaria.Web.Application.Marca;
using Concessionaria.Web.Application.Marca.Model;
using System.Web.Mvc;
using Concessionaria.Web.Infra;
using Concessionaria.Web.Application.Modelo;

namespace Concessionaria.Web.Controllers
{
    public class MarcaController : BaseController
    {
        // Instâncias das aplicações e serviços injetados no controlador
        private readonly MarcaApplication _marcaApplication;
   

        public MarcaController(MarcaApplication marcaApplication)  // Construtor que recebe o serviço `MarcaApplication` como dependência.
        {
            _marcaApplication = marcaApplication;  // Inicializa a variável `_marcaApplication` com a instância recebida.
        }

        // GET: Marca
        public ActionResult Index()                 // Método responsável por exibir a página inicial (listagem ou grid) de Marcas.
        {
            return View();                          // Retorna a View padrão associada à ação `Index`.
        }

        public ActionResult ListarMarcas()          // Método para listar as marcas cadastradas.
        {
            var response = _marcaApplication.BuscarMarcas();
            return View("_GridMarcas", response.Content);
        }

        public ActionResult Adicionar()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Adicionar(MarcaModel model)
        {

            var marcasExistentes = _marcaApplication.BuscarMarcas();

            // Passo 2: Verificar se a nova marca já existe
            foreach (var marca in marcasExistentes.Content)
            {
                if (marca.Marca == model.Marca)  // Verifica se o nome da marca é igual ao nome da nova marca
                {
                    // Se a marca já existir, retorna um JSON informando o erro
                    return Json(new { success = false, message = "A marca já existe." });
                }
            }
            if (model.Marca == null)
            {
                return Json(new { success = false, message = "A marca não pode estar vazia." });
            }

            if (ModelState.IsValid)
            {
                // Chama o método para adicionar a marca via `MarcaApplication`
                var response = _marcaApplication.Post(model);

               
                {
                    // Retorna um JSON indicando sucesso
                    return Json(new { success = true, message = "Marca adicionada com sucesso!" });
                  
                }
            }

            // Retorna um JSON indicando falha
            return Json(new { success = false, message = "Falha ao adicionar marca." });
        }

        // Método para carregar os dados da marca para edição
        public ActionResult Editar(int id)
        {

            var response = _marcaApplication.BuscarMarcaPorId(id); // Método para buscar a marca pelo ID
            return View(response.Content); // Retorna a View para editar a marca
        }

        [HttpPost]
        public ActionResult Editar(MarcaModel model)
        {

            var marcasExistentes = _marcaApplication.BuscarMarcas();

            // Passo 2: Verificar se a nova marca já existe
            foreach (var marca in marcasExistentes.Content)
            {
                if (marca.Marca == model.Marca)  // Verifica se o nome da marca é igual ao nome da nova marca
                {
                    // Se a marca já existir, retorna um JSON informando o erro
                    return Json(new { success = false, message = "A marca já existe nao pode ser editada." });
                }
            }

            if (model.Marca == null) {
                return Json(new { success = false, message = "A marca não pode estar vazia." });
            }
            if (ModelState.IsValid)
            {
                var response = _marcaApplication.Put(model); // Método para atualizar a marca
                return Json(new { success = true, message = "Marca atualizada com sucesso!" });
            }

            return Json(new { success = false, message = "Falha ao atualizar a marca." });
        }

        public ActionResult Excluir(int id)
        {
            // Valida se a marca está associada a algum modelo
            var validacaoResponse = _marcaApplication.ValidarMarcaEmodelo(id).Content;

            // Se o valor retornado for 0, significa que a marca não está associada a nenhum modelo
            if (validacaoResponse == false)
            {
                // Tenta excluir a marca
                var response = _marcaApplication.Delete(id); // Supondo que Delete retorne Response<bool>

                // Acessa o conteúdo da resposta para verificar o sucesso da exclusão
                bool sucesso = response.Ok;  // Acessa o valor real do sucesso (true ou false)

                if (sucesso)  // Se a exclusão foi bem-sucedida (true)
                {
                    return Json(new { success = true, message = "Marca excluída com sucesso!" });
                }
                else
                {
                    return Json(new { success = false, message = "Falha ao excluir a marca." });
                }
            }
            else
            {
                // Se a marca estiver associada a um modelo, não pode ser excluída
                return Json(new { success = false, message = "Não é possível excluir a marca porque está associada a um modelo." });
            }
        }


    }
}

