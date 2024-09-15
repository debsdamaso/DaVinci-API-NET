using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DaVinci.Models.Mapping
{
    public class ProdutosMapping : IEntityTypeConfiguration<Produtos>
    {
        public void Configure(EntityTypeBuilder<Produtos> builder)
        {
            builder.ToTable("TB_DV_PRODUTO");

            builder.HasKey(p => p.IdProduto);

            builder.Property(p => p.Nome)
               .HasMaxLength(100);

            builder.Property(p => p.Valor)
               .HasColumnType("decimal(18, 2)");

            builder.Property(p => p.Categoria)
               .HasMaxLength(50);  

            builder.Property(p => p.Modelo)
               .HasMaxLength(50); 

        }
    }
}
