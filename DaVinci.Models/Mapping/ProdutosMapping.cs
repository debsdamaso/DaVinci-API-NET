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

            builder.HasOne(p => p.Cliente)
               .WithMany(c => c.Produtos)
               .HasForeignKey(p => p.IdCliente)
               .OnDelete(DeleteBehavior.Restrict);  

            builder.HasMany(p => p.Feedbacks)
               .WithOne(f => f.Produto)
               .HasForeignKey(f => f.IdProduto)
               .OnDelete(DeleteBehavior.Cascade); 
        }
    }
}
