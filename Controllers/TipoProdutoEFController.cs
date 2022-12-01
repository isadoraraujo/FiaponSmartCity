using FiaponSmartCity.Models;
using FiaponSmartCity.Repository;
using Microsoft.AspNetCore.Mvc;

namespace FiaponSmartCity.Controllers
{
    public class TipoProdutoEFController : Controller
    {

        private readonly TipoProdutoRepositoryEF tipoProdutoRepositoryEF;

        public TipoProdutoEFController()
        {
            this.tipoProdutoRepositoryEF = new TipoProdutoRepositoryEF();
        }

        [Filtros.LogFilter]
        [HttpGet]
        public IActionResult Index()
        {
            var listaTipo = tipoProdutoRepositoryEF.Listar();
            return View(listaTipo);
        }

        [HttpGet]
        public ActionResult Cadastrar()
        {
            return View(new TipoProdutoEF());
        }

        [HttpPost]
        public ActionResult Cadastrar(TipoProdutoEF produtoEF)
        {
            if (ModelState.IsValid)
            {
                tipoProdutoRepositoryEF.Inserir(produtoEF);

                @TempData["mensagem"] = "Tipo cadastrado com sucesso!";
                return RedirectToAction("Index", "TipoProdutoEF");

            }
            else
            {
                return View(produtoEF);
            }
        }

        [HttpGet]
        public ActionResult Editar(int Id)
        {
            var TipoProdutoEF = tipoProdutoRepositoryEF.Consultar(Id);
            return View(TipoProdutoEF);
        }

        [HttpPost]
        public ActionResult Editar(Models.TipoProdutoEF TipoProdutoEF)
        {

            if (ModelState.IsValid)
            {
                tipoProdutoRepositoryEF.Alterar(TipoProdutoEF);

                @TempData["mensagem"] = "Tipo alterado com sucesso!";
                return RedirectToAction("Index", "TipoProdutoEF");
            }
            else
            {
                return View(TipoProdutoEF);
            }

        }

        [HttpGet]
        public ActionResult Consultar(int Id)
        {
            var TipoProdutoEF = tipoProdutoRepositoryEF.Consultar(Id);
            return View(TipoProdutoEF);
        }

        [HttpGet]
        public ActionResult ConsultarProduto(int Id)
        {
            var Produto = tipoProdutoRepositoryEF.Consultar(Id);
            return View(Produto);
        }

        [HttpGet]
        public ActionResult Excluir(int Id)
        {
            tipoProdutoRepositoryEF.Excluir(Id);

            @TempData["mensagem"] = "Tipo removido com sucesso!";

            return RedirectToAction("Index", "TipoProdutoEF");
        }
    }
}