using System;
using System.Collections.Generic;
using System.Linq;
using CrdFortes.Domain.Entities;
using CrdFortes.Domain.Interfaces.Repositories;

namespace CrdFortes.Infra.Data.Repositories
{
    public class OperacaoRepository : RepositoryBase<Operacao>, IOperacaoRepository
    {
        public IEnumerable<Operacao> Filtro(EnumTipoOperacao? tipoOperacao, string categoria, string dataInicial, string dataFinal)
        {
            if (string.IsNullOrEmpty(dataInicial))
                dataInicial = "01/01/1900 00:00:00";

            if (string.IsNullOrEmpty(dataFinal))
                dataFinal = DateTime.Now.ToString("dd-MM-yyyy");

            DateTime dtInicio = Convert.ToDateTime(dataInicial);
            DateTime dtFinal = Convert.ToDateTime(string.Format("{0} 23:59:59", dataFinal));


            return Db.Despesas.Where(c => c.TipoOperacao == tipoOperacao && 
                    c.Categoria.Contains(categoria) &&
                    c.DataCadastro >= dtInicio && c.DataCadastro <= dtFinal);



        }
    }
}
