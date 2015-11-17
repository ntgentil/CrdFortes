using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using CrdFortes.Application.Interface;
using CrdFortes.Domain.Entities;
using CrdFortes.MVC.ViewModels;

namespace CrdFortes.MVC.Controllers
{
    public class DespesasController : Controller
    {
        private readonly IOperacaoAppService _operacaoApp;

        public DespesasController(IOperacaoAppService operacaoApp)
        {
            _operacaoApp = operacaoApp;
        }

        public ActionResult Index(string categoria, string dataInicial, string dataFinal)
        {
            var despesaViewModel = Mapper.Map<IEnumerable<Operacao>, IEnumerable<OperacaoViewModel>>(_operacaoApp.Filtro(EnumTipoOperacao.Despesa, categoria, dataInicial, dataFinal));

            return View(despesaViewModel);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OperacaoViewModel despesa)
        {
            if (ModelState.IsValid)
            {
                var despesaDomain = Mapper.Map<OperacaoViewModel, Operacao>(despesa);

                _operacaoApp.Add(despesaDomain);

                return RedirectToAction("Index");
            }
            return View(despesa);
        }

        public ActionResult Edit(int id)
        {
            var despesa = _operacaoApp.GetById(id);
            var despesaViewModel = Mapper.Map<Operacao, OperacaoViewModel>(despesa);

            return View(despesaViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(OperacaoViewModel despesa)
        {
            if (ModelState.IsValid)
            {
                var despesaDomain = Mapper.Map<OperacaoViewModel, Operacao>(despesa);
                _operacaoApp.Update(despesaDomain);

                return RedirectToAction("Index");
            }
            return View(despesa);
        }

        public ActionResult Delete(int id)
        {
            var despesa = _operacaoApp.GetById(id);
            var despesaViewModel = Mapper.Map<Operacao, OperacaoViewModel>(despesa);

            return View(despesaViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var despesa = _operacaoApp.GetById(id);
            _operacaoApp.Remove(despesa);

           return RedirectToAction("Index");
        }
    }
}
