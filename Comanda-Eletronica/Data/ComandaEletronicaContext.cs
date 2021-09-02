using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    }
}
