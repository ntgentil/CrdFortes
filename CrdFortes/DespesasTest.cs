using System;
using System.Configuration;
using CrdFortes.Domain.Entities;
using CrdFortes.Infra.Data.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace CrdFortes
{
    [TestClass]
    public class DespesasTest
    {
        private DespesaRepository _despesaRepository;

        [TestInitialize]
        public void Initialize()
        {
            _despesaRepository = new DespesaRepository();
        }

        [TestMethod]
        public void DeveCadastrarDespesa()
        {
            var despesa = new Despesa
            {
                DespesaId = 1,
                Categoria = "Conta",
                DataCadastro = DateTime.Now,
                Observacao = "Conta Celular Oi",
                Valor = Convert.ToDecimal("120,00")
            };

            _despesaRepository.Add(despesa);

            var result = _despesaRepository.GetById(1);

            Assert.IsNotNull(result);
            Assert.AreEqual("Conta", result.Categoria);
        }


        [TestMethod]
        public void CreateContactRequiredFirstName()
        {
            Assert.Fail();  
        }


        [TestMethod]
        public void CreateContactRequiredLastName()
        {
            Assert.Fail();  
        }

        [TestMethod]
        public void CreateContactInvalidPhone()
        {
            Assert.Fail();  
        }


        [TestMethod]
        public void CreateContactInvalidEmail()
        {
            Assert.Fail();  
        }
    }
}