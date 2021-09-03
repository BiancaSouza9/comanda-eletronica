using Comanda_Eletronica.Models;
using System.Collections.Generic;
using Comanda_Eletronica.Entities.Enums;
using Comanda_Eletronica.Entities;

namespace Comanda_Eletronica.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        List<Produto> GetProdutos(int id);
        List<Mesa> GetMesas(int id);
        void SetMesa(int id, string status_mesa);
    }
}