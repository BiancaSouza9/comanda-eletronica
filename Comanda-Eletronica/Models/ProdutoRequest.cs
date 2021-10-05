using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Comanda_Eletronica.Models
{
    public class ProdutoRequest
    {
        public int IdProduto { get; set; }
        public string Produto { get; set; }
        public string Categoria { get; set; }
        public decimal Valor { get; set; }
    }
}