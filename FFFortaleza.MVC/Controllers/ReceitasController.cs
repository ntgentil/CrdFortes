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
        private readonly IOperacaoAppService _operacaoApp;

        public ReceitasController(IOperacaoAppService operacaoApp)
        {
            _operacaoApp = operacaoApp;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Filtro(string categoria, string dataInicial, string dataFinal)
        {
           
            var receitaViewModel = Mapper.Map<IEnumerable<Operacao>, IEnumerable<OperacaoViewModel>>(_operacaoApp.Filtro(EnumTipoOperacao.Receita, categoria, dataInicial, dataFinal));

            return Json(receitaViewModel, JsonRequestBehavior.AllowGet);
            
        }

        // GET: Receita/Details/5
        public ActionResult Details(int id)
        {
            var receita = _operacaoApp.GetById(id);
            var receitaViewModel = Mapper.Map<Operacao, OperacaoViewModel>(receita);

            return Json(receitaViewModel, JsonRequestBehavior.AllowGet);
        }

        // GET: Receita/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Receita/Create
        [HttpPost]
        public ActionResult Create(OperacaoViewModel receita)
        {
            if (receita == null) return Json(null);

            receita.TipoOperacao = EnumTipoOperacao.Receita;
            receita.DataCadastro = DateTime.Now;

            var receitaDomain = Mapper.Map<OperacaoViewModel, Operacao>(receita);

            _operacaoApp.Add(receitaDomain);

            return Json(receita, JsonRequestBehavior.AllowGet);
        }

        // GET: Receita/Edit/5
        public ActionResult Edit(int id)
        {
            var receita = _operacaoApp.GetById(id);
            var receitaViewModel = Mapper.Map<Operacao, OperacaoViewModel>(receita);

            return Json(receitaViewModel, JsonRequestBehavior.AllowGet);
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

                return Json(receita, JsonRequestBehavior.AllowGet);
            }
            return Json(null);
        }

        
        // POST: Receita/Delete/5
        public ActionResult Delete(int id)
        {
            var receita = _operacaoApp.GetById(id);
            _operacaoApp.Remove(receita);

            return Json(new { Status = true }, JsonRequestBehavior.AllowGet);
        }
    }
}
