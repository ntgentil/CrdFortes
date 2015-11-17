using System.Collections.Generic;
using CrdFortes.Application.Interface;
using CrdFortes.Domain.Entities;
using CrdFortes.Domain.Interfaces.Services;

namespace CrdFortes.Application
{
    public class OperacaoAppService : AppServiceBase<Operacao>, IOperacaoAppService
    {
        private readonly IOperacaoService _operacaoService;

        public OperacaoAppService(IOperacaoService operacaoService) : base(operacaoService)
        {
            _operacaoService = operacaoService;
        }

        public IEnumerable<Operacao> Filtro(EnumTipoOperacao? tipoOperacao, string categoria, string dataInicial, string dataFinal)
        {
            return _operacaoService.Filtro(tipoOperacao, categoria, dataInicial, dataFinal);
        }

        public IEnumerable<string> GetCategorias()
        {
            return _operacaoService.GetCategorias();
        }
    }
}
