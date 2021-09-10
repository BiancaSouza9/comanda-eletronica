using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Comanda_Eletronica.Models
{
    public class LoginRequest
    {
        public int id_funcionario_pk { get; set; }
        public string nome { get; set; }
        public string usuario { get; set; }
        public string senha { get; set; }
        public int id_modulo_fk { get; set; }
    }
}