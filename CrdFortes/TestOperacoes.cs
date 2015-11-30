using System;
using System.Collections.Generic;
using System.Linq;
using CrdFortes.Domain.Entities;
using CrdFortes.Domain.Interfaces.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CrdFortes
{
    [TestClass]
    public class TestOperacoes
    {

        public TestOperacoes()
        {
            IList<Operacao> operacoes = new List<Operacao>
                {
                    new Operacao { OperacaoId = 1, TipoOperacao = EnumTipoOperacao.Receita, Observacao = "Novembro ", Categoria = "Salario", DataCadastro = DateTime.Now.Add(new TimeSpan(-3)) ,Valor = (decimal) 49.99 },
                    new Operacao { OperacaoId = 2, TipoOperacao = EnumTipoOperacao.Despesa, Observacao = "Conta Dezembro", Categoria = "Conta 1", DataCadastro = DateTime.Now.Add(new TimeSpan(-2)), Valor = (decimal) 49.99 },
                    new Operacao { OperacaoId = 3, TipoOperacao = EnumTipoOperacao.Receita, Observacao = "Janeiro", Categoria = "Salario", DataCadastro = DateTime.Now.Add(new TimeSpan(-1)) ,Valor = (decimal) 49.99 },
                    new Operacao { OperacaoId = 4, TipoOperacao = EnumTipoOperacao.Despesa, Observacao = "Conta Fevereiro", Categoria = "Conta 2", DataCadastro = DateTime.Now ,Valor = (decimal) 49.99 },
                    new Operacao { OperacaoId = 5, TipoOperacao = EnumTipoOperacao.Receita, Observacao = "Novembro ", Categoria = "Salario", DataCadastro = DateTime.Now.Add(new TimeSpan(-3)) ,Valor = (decimal) 49.99 },
                    new Operacao { OperacaoId = 6, TipoOperacao = EnumTipoOperacao.Despesa, Observacao = "Conta Dezembro", Categoria = "Conta 1", DataCadastro = DateTime.Now.Add(new TimeSpan(-2)), Valor = (decimal) 49.99 },
                    new Operacao { OperacaoId = 7, TipoOperacao = EnumTipoOperacao.Receita, Observacao = "Janeiro", Categoria = "Salario", DataCadastro = DateTime.Now.Add(new TimeSpan(-1)) ,Valor = (decimal) 49.99 },
                    new Operacao { OperacaoId = 8, TipoOperacao = EnumTipoOperacao.Despesa, Observacao = "Conta Fevereiro", Categoria = "Conta 2", DataCadastro = DateTime.Now ,Valor = (decimal) 49.99 }
                };

            var categorias = new[]{"Salario","Conta 1", "Conta 2"};

            var mockOperacaoRepository = new Mock<IOperacaoRepository>();

            mockOperacaoRepository.Setup(o => o.GetAll()).Returns(operacoes);

            mockOperacaoRepository.Setup(o => o.GetCategorias()).Returns(categorias);

            mockOperacaoRepository.Setup(o => o.GetById(It.IsAny<int>())).Returns((int i) => operacoes.Single(x => x.OperacaoId == i));

            mockOperacaoRepository.Setup(o => o.Add(It.IsAny<Operacao>())).Callback(
                (Operacao target) =>
                {
                    var now = DateTime.Now;

                    if (target.OperacaoId.Equals(default(int)))
                    {
                        target.DataCadastro = now;
                        target.OperacaoId = operacoes.Count() + 1;
                        operacoes.Add(target);
                    }
                    else
                    {
                        var original = operacoes.Single(q => q.OperacaoId == target.OperacaoId);

                        original.Observacao = target.Observacao;
                        original.Valor = target.Valor;
                        original.Categoria = target.Categoria;
                        original.TipoOperacao = target.TipoOperacao;
                        original.DataCadastro = now;
                    }
                });

            MockProductsRepository = mockOperacaoRepository.Object;
        }

        public TestContext TestContext { get; set; }

        public readonly IOperacaoRepository MockProductsRepository;

        [TestMethod]
        public void DeveRetornarOperacaoPorId()
        {
            var operacao = MockProductsRepository.GetById(2);

            Assert.IsNotNull(operacao);
            Assert.IsInstanceOfType(operacao, typeof(Operacao));
            Assert.AreEqual("Conta Dezembro", operacao.Observacao); 
        }

        [TestMethod]
        public void DeveRetornarListaDeCategorias()
        {
            var categorias = MockProductsRepository.GetCategorias();

            Assert.IsNotNull(categorias);
            Assert.IsInstanceOfType(categorias, typeof(IEnumerable<string>)); 
            Assert.AreEqual(3, categorias.Count()) ;
        }

        [TestMethod]
        public void DeveRetonarTodasAsOperacoes()
        {
            var operacoes = MockProductsRepository.GetAll();

            Assert.IsNotNull(operacoes);
            Assert.AreEqual(8, operacoes.Count());
        }

        [TestMethod]
        public void DeveAdicionarUmaOperacao()
        {
            var novaOperacao = new Operacao { Observacao = "Debito online dezembro", Categoria = "Conta 1", Valor = (decimal) 39.99, DataCadastro = DateTime.Now, TipoOperacao = EnumTipoOperacao.Despesa};

            var resultadoCount = MockProductsRepository.GetAll().Count();
            Assert.AreEqual(8, resultadoCount);

            MockProductsRepository.Add(novaOperacao);

            resultadoCount = MockProductsRepository.GetAll().Count();
            Assert.AreEqual(9, resultadoCount); 

            var operacao = MockProductsRepository.GetById(9);
            Assert.IsNotNull(operacao);
            Assert.IsInstanceOfType(operacao, typeof(Operacao));
            Assert.AreEqual("Debito online dezembro", operacao.Observacao); 
        }

        [TestMethod]
        public void DeveAtualizarUmaOperacao()
        {
            var operacao = MockProductsRepository.GetById(1);

            operacao.Observacao = "Novembro Gentil";

            MockProductsRepository.Add(operacao);

            Assert.AreEqual("Novembro Gentil", MockProductsRepository.GetById(1).Observacao);
        }
    }
}
