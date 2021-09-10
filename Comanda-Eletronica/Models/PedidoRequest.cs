using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Comanda_Eletronica.Models
{
    public class PedidoRequest
    {
        public int IdPedido { get; set; }

        public int IdMesa { get; set; }
        public int IdFuncionario { get; set; }
        public string StatusPedido { get; set; }
        public DateTime Data { get; set; }
        public List<ItemRequest> Itens { get; set; }
    }
}