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
        private readonly IDespesaAppService _despesaApp;

        public DespesasController(IDespesaAppService despesaApp)
        {
            _despesaApp = despesaApp;
        }

        public ActionResult Index(string categoria, string dataInicial, string dataFinal)
        {
            if (string.IsNullOrEmpty(categoria) && (string.IsNullOrEmpty(dataInicial) && string.IsNullOrEmpty(dataFinal)))
            {
                var despesaViewModel = Mapper.Map<IEnumerable<Despesa>, IEnumerable<DespesaViewModel>>(_despesaApp.GetAll());

                return View(despesaViewModel);
            }
            else
            {
                var despesaViewModel = Mapper.Map<IEnumerable<Despesa>, IEnumerable<DespesaViewModel>>(_despesaApp.Filtro(categoria, dataInicial, dataFinal));

                return View(despesaViewModel);
            }

        }

        // GET: Despesas/Details/5
        public ActionResult Details(int id)
        {
            var despesa = _despesaApp.GetById(id);
            var despesaViewModel = Mapper.Map<Despesa, DespesaViewModel>(despesa);

            return View(despesaViewModel);
        }

        // GET: Despesas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Despesas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DespesaViewModel despesa)
        {
            if (ModelState.IsValid)
            {
                var despesaDomain = Mapper.Map<DespesaViewModel, Despesa>(despesa);

                _despesaApp.Add(despesaDomain);

                return RedirectToAction("Index");
            }
            return View(despesa);
        }

        // GET: Despesas/Edit/5
        public ActionResult Edit(int id)
        {
            var despesa = _despesaApp.GetById(id);
            var despsaViewModel = Mapper.Map<Despesa, DespesaViewModel>(despesa);

            return View(despsaViewModel);
        }

        // POST: Despesas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DespesaViewModel despesa)
        {
            if (ModelState.IsValid)
            {
                var despesaDomain = Mapper.Map<DespesaViewModel, Despesa>(despesa);
                _despesaApp.Update(despesaDomain);

                return RedirectToAction("Index");
            }
            return View(despesa);
        }

        // GET: Despesas/Delete/5
        public ActionResult Delete(int id)
        {
            var despesa = _despesaApp.GetById(id);
            var despesaViewModel = Mapper.Map<Despesa, DespesaViewModel>(despesa);

            return View(despesaViewModel);
        }

        // POST: Despesas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var despesa = _despesaApp.GetById(id);
            _despesaApp.Remove(despesa);

           return RedirectToAction("Index");
        }
    }
}
