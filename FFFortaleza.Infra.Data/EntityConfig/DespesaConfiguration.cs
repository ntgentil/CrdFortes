using System.Data.Entity.ModelConfiguration;
using CrdFortes.Domain.Entities;

namespace CrdFortes.Infra.Data.EntityConfig
{
    public class DespesaConfiguration : EntityTypeConfiguration<Despesa>
    {
        public DespesaConfiguration()
        {
            HasKey(d => d.DespesaId);

            Property(d => d.Categoria)
                .IsRequired();

            Property(d => d.Observacao)
                .IsRequired();

            Property(d => d.Valor)
                .IsRequired();

        }
    }
}
