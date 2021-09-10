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

        public DbSet<Produto> Produto { get; set; }
        public DbSet<Mesa> Mesa { get; set; }
        public DbSet<Funcionario> Funcionario { get; set; }
        public DbSet<Pedido> Pedido { get; set; }
        public DbSet<Item> Item { get; set; }
        public DbSet<StatusPedido> status_pedido { get; set; }
    }
}