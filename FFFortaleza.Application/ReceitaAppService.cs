using System.Collections.Generic;
using CrdFortes.Application.Interface;
using CrdFortes.Domain.Entities;
using CrdFortes.Domain.Interfaces.Services;

namespace CrdFortes.Application
{
    public class ReceitaAppService : AppServiceBase<Receita>, IReceitaService, IReceitaAppService
    {
        private readonly IReceitaService _receitaService;

        public ReceitaAppService(IReceitaService receitaService) : base(receitaService)
        {
            _receitaService = receitaService;
        }

        public IEnumerable<Receita> Filtro(string categoria, string dataInicial, string dataFinal)
        {
            return _receitaService.Filtro(categoria, dataInicial, dataFinal);
        }

       
    }
}
