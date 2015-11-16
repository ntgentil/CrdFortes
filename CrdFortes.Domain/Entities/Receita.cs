using System;

namespace CrdFortes.Domain.Entities
{
    public class Receita
    {
        public int ReceitaId { get; set; }
        public decimal Valor { get; set; }
        public string Categoria { get; set; }
        public string Observacao { get; set; }
        public DateTime DataCadastro { get; set; }

    }
}
