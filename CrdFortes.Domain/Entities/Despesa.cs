using System;

namespace CrdFortes.Domain.Entities
{
    public class Despesa
    {
        public int DespesaId { get; set; }
        public decimal Valor { get; set; }
        public string Categoria { get; set; }
        public string Observacao { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
