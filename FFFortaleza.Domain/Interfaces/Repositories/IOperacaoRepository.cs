using System;
using System.Collections.Generic;
using CrdFortes.Domain.Entities;

namespace CrdFortes.Domain.Interfaces.Repositories
{
    public interface IOperacaoRepository : IRepositoryBase<Operacao>
    {
        IEnumerable<Operacao> Filtro(EnumTipoOperacao? tipoOperacao, string categoria, string dataInicial, string dataFinal);
        IEnumerable<string> GetCategorias();
    }
}
