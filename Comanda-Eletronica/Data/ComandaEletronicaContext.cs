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

        public DbSet<Comanda_Eletronica.Models.Product> Orders { get; set; }
    }
}
