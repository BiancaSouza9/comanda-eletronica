using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Comanda_Eletronica.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome_Produto { get; set; }
    }
}
