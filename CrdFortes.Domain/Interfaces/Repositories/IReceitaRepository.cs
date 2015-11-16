using System.Collections.Generic;
using CrdFortes.Domain.Entities;

namespace CrdFortes.Domain.Interfaces.Repositories
{
    public interface IReceitaRepository: IRepositoryBase<Receita>
    {
        IEnumerable<Receita> Filtro(string categoria, string dataInicial, string dataFinal);
    }
}
