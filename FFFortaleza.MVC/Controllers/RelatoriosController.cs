using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using CrdFortes.Application.Interface;
using CrdFortes.Domain.Entities;
using CrdFortes.MVC.ViewModels;

namespace CrdFortes.MVC.Controllers
{
    public class RelatoriosController : Controller
    {
        private readonly IOperacaoAppService _operacaoApp;

        public RelatoriosController(IOperacaoAppService operacaoApp)
        {
            _operacaoApp = operacaoApp;
        }

        public ActionResult Index()
        {
            var categoriaLista = new List<SelectListItem> { new SelectListItem { Text = "Categorias", Value = "" } };
            categoriaLista.AddRange(_operacaoApp.GetCategorias().Select(item => new SelectListItem { Text = item, Value = item }));

            ViewBag.categoria = categoriaLista;

            return View();
        }

        public ActionResult Filtro(string categoria, string dataInicial, string dataFinal)
        {

            var receitaViewModel = Mapper.Map<IEnumerable<Operacao>, IEnumerable<OperacaoViewModel>>(_operacaoApp.Filtro(null, categoria, dataInicial, dataFinal));

            return Json(receitaViewModel, JsonRequestBehavior.AllowGet);
            

        }
    }
}
