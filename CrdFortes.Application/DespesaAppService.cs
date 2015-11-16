using System.Collections.Generic;
using CrdFortes.Application.Interface;
using CrdFortes.Domain.Entities;
using CrdFortes.Domain.Interfaces.Services;

namespace CrdFortes.Application
{
    public class DespesaAppService : AppServiceBase<Despesa>, IDespesaAppService
    {
        private readonly IDespesaService _despesaService;

        public DespesaAppService(IDespesaService despesaService) : base(despesaService)
        {
            _despesaService = despesaService;
        }

        public IEnumerable<Despesa> Filtro(string categoria, string dataInicial, string dataFinal)
        {
            return _despesaService.Filtro(categoria, dataInicial, dataFinal);
        }

    }
}
