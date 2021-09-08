using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Comanda_Eletronica.Entities
{
    public class Funcionario
    {
        [Key]
        public int id_funcionario { get; set; }
        public string nome { get; set; }
        public string usuario { get; set; }
        public string senha { get; set; }
        public string modulo { get; set; }
    }
}
