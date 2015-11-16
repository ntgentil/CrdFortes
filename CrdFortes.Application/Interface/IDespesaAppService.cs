using System.Collections.Generic;
using CrdFortes.Domain.Entities;

namespace CrdFortes.Application.Interface
{
    public interface IDespesaAppService : IAppServiceBase<Despesa>
    {
        IEnumerable<Despesa> Filtro(string categoria, string dataInicial, string dataFinal);
    }
}
