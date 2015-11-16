using System.Collections.Generic;
using CrdFortes.Domain.Entities;

namespace CrdFortes.Application.Interface
{
    public interface IOperacaoAppService : IAppServiceBase<Operacao>
    {
        IEnumerable<Operacao> Filtro(EnumTipoOperacao? tipoOperacao, string categoria, string dataInicial, string dataFinal);
    }
}
