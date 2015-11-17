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
        private readonly IOperacaoAppService _operacaoApp;

        public ReceitasController(IOperacaoAppService operacaoApp)
        {
            _operacaoApp = operacaoApp;
        }

        public ActionResult Index(string categoria, string dataInicial, string dataFinal)
        {
           
            var receitaViewModel = Mapper.Map<IEnumerable<Operacao>, IEnumerable<OperacaoViewModel>>(_operacaoApp.Filtro(EnumTipoOperacao.Receita, categoria, dataInicial, dataFinal));

            return View(receitaViewModel);
            

        }

        // GET: Receita/Details/5
        public ActionResult Details(int id)
        {
            var receita = _operacaoApp.GetById(id);
            var receitaViewModel = Mapper.Map<Operacao, OperacaoViewModel>(receita);

            return View(receitaViewModel);
        }

        // GET: Receita/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Receita/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OperacaoViewModel receita)
        {
            if (ModelState.IsValid)
            {
                var receitaDomain = Mapper.Map<OperacaoViewModel, Operacao>(receita);

                _operacaoApp.Add(receitaDomain);

                return RedirectToAction("Index");
            }
            return View(receita);
        }

        // GET: Receita/Edit/5
        public ActionResult Edit(int id)
        {
            var receita = _operacaoApp.GetById(id);
            var receitaViewModel = Mapper.Map<Operacao, OperacaoViewModel>(receita);

            return View(receitaViewModel);
        }

        // POST: Receita/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(OperacaoViewModel receita)
        {
            if (ModelState.IsValid)
            {
                var receitaDomain = Mapper.Map<OperacaoViewModel, Operacao>(receita);
                _operacaoApp.Update(receitaDomain);

                return RedirectToAction("Index");
            }
            return View(receita);
        }

        // GET: Receita/Delete/5
        public ActionResult Delete(int id)
        {
            var receita = _operacaoApp.GetById(id);
            var receitaViewModel = Mapper.Map<Operacao, OperacaoViewModel>(receita);

            return View(receitaViewModel);
        }

        // POST: Receita/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var receita = _operacaoApp.GetById(id);
            _operacaoApp.Remove(receita);

           return RedirectToAction("Index");
        }
    }
}
