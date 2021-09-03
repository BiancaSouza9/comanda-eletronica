using Microsoft.EntityFrameworkCore;

namespace Comanda_Eletronica.Data
{
    public class ComandaEletronicaContext : DbContext
    {
        public ComandaEletronicaContext(
            DbContextOptions<ComandaEletronicaContext> options)
            : base(options)
        {
        }

        public DbSet<Comanda_Eletronica.Models.Product> Products { get; set; }
        public DbSet<Comanda_Eletronica.Models.Produto> Produtos { get; set; }
        public DbSet<Comanda_Eletronica.Models.Mesa> Mesas { get; set; }
    }
}
