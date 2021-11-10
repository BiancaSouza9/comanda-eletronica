using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Comanda_Eletronica.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace Comanda_Eletronica.Entities
{
    public class Mesa
    {
        [Key]
        public int id_mesa_pk { get; set; }
        public MesaStatus id_status_fk { get; set; }
        public byte pessoas { get; set; }
        public Status status { get; set; }
    }
}