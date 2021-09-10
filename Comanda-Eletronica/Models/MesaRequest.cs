using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Comanda_Eletronica.Models
{
    public class MesaRequest
    {
        public int id_mesa_pk { get; set; }
        public string id_status_fk { get; set; }
        public int pessoas { get; set; }
    }
}
