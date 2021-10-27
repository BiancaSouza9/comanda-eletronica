using Comanda_Eletronica.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Comanda_Eletronica.Models
{
    public class PedidoResponse
    {
        public int id_pedido_pk { get; set; }
        public int id_mesa_fk { get; set; }
        public int id_funcionario_fk { get; set; }
        public PedidoStatus id_status_ped_fk { get; set; }
        public DateTime data { get; set; }
        public List<ItemResponse> itens { get; set; }
    }

    public class ItemResponse
    {
        public int id_item_pk { get; set; }
        public int id_pedido_fk { get; set; }
        public int id_produto_fk { get; set; }
        public int quantidade { get; set; }
        public decimal valor { get; set; }
        public string nomeProduto { get; set; }
    }
}
