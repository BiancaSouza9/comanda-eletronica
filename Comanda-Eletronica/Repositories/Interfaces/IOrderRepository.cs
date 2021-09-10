using Comanda_Eletronica.Models;
using System.Collections.Generic;
using Comanda_Eletronica.Entities.Enums;
using Comanda_Eletronica.Entities;
using System;

namespace Comanda_Eletronica.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        List<Produto> GetProdutos(int id);
        List<Mesa> GetMesas(int id);
        List<Pedido> GetPedido(int id);
        void SetMesa(int id, string status_mesa);
        void AddPedido(PedidoRequest pedidoRequest);
    }
}