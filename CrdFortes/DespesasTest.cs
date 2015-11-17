using System;
using System.Data.SqlClient;
using CrdFortes.Domain.Entities;
using CrdFortes.Infra.Data.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace CrdFortes
{
    [TestClass]
    public class DespesasTest
    {
        private OperacaoRepository _operacaoRepository;

        public DespesasTest(OperacaoRepository operacaoRepository)
        {
            _operacaoRepository = operacaoRepository;
        }
        
        public DespesasTest()
        {}

        [TestInitialize]
        public void Initialize()
        {
            _operacaoRepository = new OperacaoRepository();
        }

        [TestMethod]
        [ExpectedException(typeof(SqlException))]
        public void DeveCadastrarDespesa()
        {
            var despesa = new Operacao
            {
                OperacaoId = 1,
                Categoria = null,
                DataCadastro = DateTime.Now,
                Observacao = null,
                Valor = Convert.ToDecimal("120,00")
            };

            _operacaoRepository.Add(despesa);

        }
        [TestMethod]
        public void DeveCadastrarDespesa1()
        {
            
            var x = _operacaoRepository.GetAll();

            Assert.IsNotNull(x);

        }

       
    }
}