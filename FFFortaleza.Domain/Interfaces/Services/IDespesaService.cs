using System.Collections.Generic;
using CrdFortes.Domain.Entities;

namespace CrdFortes.Domain.Interfaces.Services
{
    public interface IDespesaService : IServiceBase<Despesa>
    {
        IEnumerable<Despesa> Filtro(string categoria, string dataInicial, string dataFinal);
    }
}
