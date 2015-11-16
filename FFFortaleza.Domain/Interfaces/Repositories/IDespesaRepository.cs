using System.Collections.Generic;
using CrdFortes.Domain.Entities;

namespace CrdFortes.Domain.Interfaces.Repositories
{
    public interface IDespesaRepository : IRepositoryBase<Despesa>
    {
        IEnumerable<Despesa> Filtro(string categoria, string dataInicial, string dataFinal);
    }
}
