using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Comanda_Eletronica.Entities
{
    public class StatusPedido
    {
        [Key]
        public int id_status_ped_pk { get; set; }
        public string descricao { get; set; }
    }
}