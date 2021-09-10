using Microsoft.EntityFrameworkCore;
using Comanda_Eletronica.Entities;
using Comanda_Eletronica.Models;

namespace Comanda_Eletronica.Data
{
    public class ComandaEletronicaContext : DbContext
    {
        public ComandaEletronicaContext(
            DbContextOptions<ComandaEletronicaContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>()
                .HasOne(p => p.pedido)
                .WithMany(b => b.itens)
                .HasForeignKey(p => p.id_pedido_fk);
        }

        public DbSet<Produto> Produto { get; set; }
        public DbSet<Mesa> Mesa { get; set; }
        public DbSet<Funcionario> Funcionario { get; set; }
        public DbSet<Pedido> Pedido { get; set; }
        public DbSet<Item> Item { get; set; }
        public DbSet<StatusPedido> status_pedido { get; set; }
    }
}