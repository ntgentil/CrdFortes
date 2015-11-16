using System.Collections.Generic;
using CrdFortes.Domain.Entities;

namespace CrdFortes.Application.Interface
{
    public interface IReceitaAppService : IAppServiceBase<Receita>
    {
        IEnumerable<Receita> Filtro(string categoria, string dataInicial, string dataFinal);
    }
}
