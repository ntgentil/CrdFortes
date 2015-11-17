using System.Collections.Generic;
using CrdFortes.Domain.Entities;
using CrdFortes.Domain.Interfaces.Repositories;
using CrdFortes.Domain.Interfaces.Services;

namespace CrdFortes.Domain.Services
{
    public class OperacaoService : ServiceBase<Operacao>, IOperacaoService
    {
        private readonly IOperacaoRepository _operacaoRepository;

        public OperacaoService(IOperacaoRepository operacaoRepository)
            :base(operacaoRepository)
        {
            _operacaoRepository = operacaoRepository;
        }

        public IEnumerable<Operacao> Filtro(EnumTipoOperacao? tipoOperacao, string categoria, string dataInicial, string dataFinal)
        {
            return _operacaoRepository.Filtro(tipoOperacao, categoria, dataInicial, dataFinal);
        }

        public IEnumerable<string> GetCategorias()
        {
            return _operacaoRepository.GetCategorias();
        }
    }
}
