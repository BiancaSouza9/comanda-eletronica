using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Comanda_Eletronica.Models
{
    public class MesaRequest
    {
        public int IdMesa { get; set; }
        public string IdStatus { get; set; }
        public int Pessoas { get; set; }
    }
}
