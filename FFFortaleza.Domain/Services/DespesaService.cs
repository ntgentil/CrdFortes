using System.Collections.Generic;
using CrdFortes.Domain.Entities;
using CrdFortes.Domain.Interfaces.Repositories;
using CrdFortes.Domain.Interfaces.Services;

namespace CrdFortes.Domain.Services
{
    public class DespesaService : ServiceBase<Despesa>, IDespesaService
    {
        private readonly IDespesaRepository _despesaRepository;

        public DespesaService(IDespesaRepository despesaRepository)
            :base(despesaRepository)
        {
            _despesaRepository = despesaRepository;
        }

        public IEnumerable<Despesa> Filtro(string categoria, string dataInicial, string dataFinal)
        {
            return _despesaRepository.Filtro(categoria, dataInicial, dataFinal);
        }


    }
}
