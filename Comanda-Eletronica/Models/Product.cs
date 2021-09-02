using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Comanda_Eletronica.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
    }
}
