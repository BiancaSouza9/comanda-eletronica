using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Comanda_Eletronica.Entities.Enums
{
    public enum PedidoStatus : byte
    {
        Aberto = 1,
        Preparando = 2,
        Concluido = 3
    }
}