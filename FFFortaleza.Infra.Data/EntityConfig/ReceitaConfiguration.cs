using System.Data.Entity.ModelConfiguration;
using CrdFortes.Domain.Entities;

namespace CrdFortes.Infra.Data.EntityConfig
{
    public class ReceitaConfiguration : EntityTypeConfiguration<Receita>
    {
        public ReceitaConfiguration()
        {
            HasKey(r => r.ReceitaId);

            Property(r => r.Categoria)
                .IsRequired();
            
            Property(r => r.Observacao)
                .IsRequired();
            
            Property(r => r.Valor)
                .IsRequired();
        }
    }
}
