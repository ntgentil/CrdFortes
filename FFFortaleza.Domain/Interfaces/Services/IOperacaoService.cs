using System.Collections.Generic;
using CrdFortes.Domain.Entities;

namespace CrdFortes.Domain.Interfaces.Services
{
    public interface IOperacaoService : IServiceBase<Operacao>
    {
        IEnumerable<Operacao> Filtro(EnumTipoOperacao? tipoOperacao, string categoria, string dataInicial, string dataFinal);
    }
}
