using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Comanda_Eletronica.Models
{
    public class FuncionarioRequest
    {
        public int IdFuncionario { get; set; }
        public string Nome { get; set; }
        public string Usuario { get; set; }
        public string Senha { get; set; }
        public string IdModulo { get; set; }
        public string Email { get; set; }
    }
}
