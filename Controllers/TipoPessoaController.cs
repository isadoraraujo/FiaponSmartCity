using FiaponSmartCity.Models;
using FiaponSmartCity.Repository;
using Microsoft.AspNetCore.Mvc;

namespace FiaponSmartCity.Controllers
{
    public class TipoPessoaController : Controller
    {

        private readonly PessoasRepository tipoPessoaRepository;

        public TipoPessoaController()
        {
            tipoPessoaRepository = new PessoasRepository();
        }

        [Filtros.LogFilter]
        [HttpGet]
        public IActionResult Index()
        {
            var listaTipo = tipoPessoaRepository.Listar();
            return View(listaTipo);
        }

        [HttpGet]
        public ActionResult Cadastrar()
        {
            return View(new TipoPessoa());
        }

        [HttpPost]
        public ActionResult Cadastrar(Models.TipoPessoa tipoPessoa)
        {
            if (ModelState.IsValid)
            {
                tipoPessoaRepository.Inserir(tipoPessoa);

                @TempData["mensagem"] = "Tipo cadastrado com sucesso!";
                return RedirectToAction("Index", "TipoPessoa");
            }
            else
            {
                return View(tipoPessoa);
            }
        }

        [HttpGet]
        public ActionResult Editar(int Id)
        {
            var tipoPessoa = tipoPessoaRepository.Consultar(Id);
            return View(tipoPessoa);
        }

        [HttpPost]
        public ActionResult Editar(Models.TipoPessoa tipoPessoa)
        {

            if (ModelState.IsValid)
            {
                tipoPessoaRepository.Alterar(tipoPessoa);

                @TempData["mensagem"] = "Tipo alterado com sucesso!";
                return RedirectToAction("Index", "TipoPessoa");
            }
            else
            {
                return View(tipoPessoa);
            }

        }

        [HttpGet]
        public ActionResult Consultar(int Id)
        {
            var tipoPessoa = tipoPessoaRepository.Consultar(Id);
            return View(tipoPessoa);
        }

        [HttpGet]
        public ActionResult Excluir(int Id)
        {
            tipoPessoaRepository.Excluir(Id);

            @TempData["mensagem"] = "Tipo removido com sucesso!";

            return RedirectToAction("Index", "TipoPessoa");
        }

    }
}