using Comanda_Eletronica.Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Comanda_Eletronica.Entities
{
    public class Produto
    {
        [Key]
        public int id_produto_pk { get; set; }
        public string produto { get; set; }
        public Categoria id_categoria_fk { get; set; }
        public decimal valor { get; set; }
        public Status status { get; set; }
    }
}