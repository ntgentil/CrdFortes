using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

       
    }
}