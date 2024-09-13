using Microsoft.EntityFrameworkCore;
using DaVinci.Models;
using DaVinci.Models.Mapping;

namespace DaVinci.Database
{
    public class AzureDbContext : DbContext
    {
        public DbSet<Produtos> Produtos { get; set; }
        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Feedbacks> Feedbacks { get; set; }

        public AzureDbContext(DbContextOptions<AzureDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProdutosMapping());
            modelBuilder.ApplyConfiguration(new ClientesMapping());
            modelBuilder.ApplyConfiguration(new FeedbacksMapping());

            base.OnModelCreating(modelBuilder);
        }
    }
}
