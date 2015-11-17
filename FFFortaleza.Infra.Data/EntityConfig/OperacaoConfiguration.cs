using System.Data.Entity.ModelConfiguration;
using CrdFortes.Domain.Entities;

namespace CrdFortes.Infra.Data.EntityConfig
{
    public class OperacaoConfiguration : EntityTypeConfiguration<Operacao>
    {
        public OperacaoConfiguration()
        {
            HasKey(d => d.OperacaoId);

            Property(d => d.TipoOperacao)
                .IsRequired();

            Property(d => d.Categoria)
                .IsRequired();

            Property(d => d.Observacao)
                .IsRequired();

            Property(d => d.Valor)
                .IsRequired();

        }
    }
}
