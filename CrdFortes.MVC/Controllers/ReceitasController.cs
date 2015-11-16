using System;
using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using CrdFortes.Application.Interface;
using CrdFortes.Domain.Entities;
using CrdFortes.MVC.ViewModels;

namespace CrdFortes.MVC.Controllers
{
    public class ReceitasController : Controller
    {

        private readonly IReceitaAppService _receitaApp;

        public ReceitasController(IReceitaAppService receitaApp)
        {
            _receitaApp = receitaApp;
        }

        public ActionResult Index(string categoria, string dataInicial, string dataFinal)
        {
            if (string.IsNullOrEmpty(categoria) && (string.IsNullOrEmpty(dataInicial) && string.IsNullOrEmpty(dataFinal)))
            {
                 var receitaViewModel = Mapper.Map<IEnumerable<Receita>, IEnumerable<ReceitaViewModel>>(_receitaApp.GetAll());

                 return View(receitaViewModel);
            }
            else
            {
                var receitaViewModel = Mapper.Map<IEnumerable<Receita>, IEnumerable<ReceitaViewModel>>(_receitaApp.Filtro(categoria, dataInicial, dataFinal));

               return View(receitaViewModel);
            }

        }

        // GET: Receitas/Details/5
        public ActionResult Details(int id)
        {
            var receita = _receitaApp.GetById(id);
            var receitaViewModel = Mapper.Map<Receita, ReceitaViewModel>(receita);

            return View(receitaViewModel);
        }

        // GET: Receitas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Receitas/Create
        [HttpPost]
        public ActionResult Create(ReceitaViewModel receita)
        {
            if (ModelState.IsValid)
            {
                var receitaDomain = Mapper.Map<ReceitaViewModel, Receita>(receita);

                _receitaApp.Add(receitaDomain);

                return RedirectToAction("Index");
            }
            return View(receita);
        }

        // GET: Receitas/Edit/5
        public ActionResult Edit(int id)
        {
            var categoria = _receitaApp.GetById(id);
            var categoriaViewModel = Mapper.Map<Receita, ReceitaViewModel>(categoria);

            return View(categoriaViewModel);
        }

        // POST: Receitas/Edit/5
        [HttpPost]
        public ActionResult Edit(ReceitaViewModel receita)
        {
            if (ModelState.IsValid)
            {
                var receitasDomain = Mapper.Map<ReceitaViewModel, Receita>(receita);
                _receitaApp.Update(receitasDomain);

                return RedirectToAction("Index");
            }
            return View(receita);
        }

        // GET: Receitas/Delete/5
        public ActionResult Delete(int id)
        {
            var receita = _receitaApp.GetById(id);
            var receitaViewModel = Mapper.Map<Receita, ReceitaViewModel>(receita);

            return View(receitaViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var receita = _receitaApp.GetById(id);
            _receitaApp.Remove(receita);

            return RedirectToAction("Index");
        }
    }
}
