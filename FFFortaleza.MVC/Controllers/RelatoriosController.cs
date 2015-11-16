using System.Collections.Generic;
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

        public ActionResult Index(string categoria, string dataInicial, string dataFinal)
        {

            var categoriaLista = new List<SelectListItem> {new SelectListItem {Text = "Categorias", Value = ""}};

            foreach (var item in _operacaoApp.GetCategorias())
            {
                categoriaLista.Add(new SelectListItem { Text = item, Value = item });
            }

            ViewBag.categoria = categoriaLista;

            var receitaViewModel = Mapper.Map<IEnumerable<Operacao>, IEnumerable<OperacaoViewModel>>(_operacaoApp.Filtro(null, categoria, dataInicial, dataFinal));

            return View(receitaViewModel);
            

        }
    }
}
