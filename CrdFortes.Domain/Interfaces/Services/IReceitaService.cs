using System.Collections.Generic;
using CrdFortes.Domain.Entities;

namespace CrdFortes.Domain.Interfaces.Services
{
    public interface IReceitaService : IServiceBase<Receita>
    {
        IEnumerable<Receita> Filtro(string categoria, string dataInicial, string dataFinal);
    }
}
    