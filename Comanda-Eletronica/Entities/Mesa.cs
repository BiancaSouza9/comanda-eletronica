using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Comanda_Eletronica.Entities.Enums;

namespace Comanda_Eletronica.Entities
{
    public class Mesa
    {
        public int Id { get; set; }
        public MesaStatus Status_Mesa { get; set; }
    }
}
