using System.Collections.Generic;
using CrdFortes.Domain.Entities;
using CrdFortes.Domain.Interfaces.Repositories;
using CrdFortes.Domain.Interfaces.Services;

namespace CrdFortes.Domain.Services
{
    public class ReceitaService : ServiceBase<Receita>, IReceitaService
    {
        private readonly IReceitaRepository _receitaRepository;

        public ReceitaService(IReceitaRepository receitaRepository)
            :base(receitaRepository)
        {
            _receitaRepository = receitaRepository;
        }

        public IEnumerable<Receita> Filtro(string categoria, string dataInicial, string dataFinal)
        {
            return _receitaRepository.Filtro(categoria, dataInicial, dataFinal);
        }
    }
}
