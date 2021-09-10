using System;
using Comanda_Eletronica.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace Comanda_Eletronica.Entities
{
    public class Pedido
    {
        [Key]
        public int id_pedido_pk { get; set; }

        public int id_mesa_fk { get; set; }
        public int id_funcionario_fk { get; set; }
        public PedidoStatus id_status_ped_fk { get; set; }
        public DateTime data { get; set; }
    }
}
