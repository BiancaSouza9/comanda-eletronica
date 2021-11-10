using Comanda_Eletronica.Entities;
using Comanda_Eletronica.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Comanda_Eletronica.Repositories.Interfaces
{
    public interface IAdmTableRepository
    {
        void AdicionaMesa(int quantidade);
        void RemoveMesa(MesaRequest mesaRequest);
        List<Mesa> BuscaMesas();
    }
}