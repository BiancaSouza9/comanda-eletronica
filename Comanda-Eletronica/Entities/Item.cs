using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Comanda_Eletronica.Models;

namespace Comanda_Eletronica.Entities
{
    public class Item
    {
        [Key]
        public int id_item_pk { get; set; }
        public int id_pedido_fk { get; set; }
        public int id_produto_fk { get; set; }
        public int quantidade { get; set; }
        public decimal valor { get; set; }
        public Pedido pedido { get; set; }

        [ForeignKey("id_produto_fk")]
        public Produto produto { get; set; }
    }
}
