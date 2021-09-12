using Comanda_Eletronica.Models;
using System.Collections.Generic;
using Comanda_Eletronica.Entities.Enums;
using Comanda_Eletronica.Entities;
using System;

namespace Comanda_Eletronica.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        List<Produto> BuscaProdutos(int id);
        List<Mesa> BuscaMesasLivres();
        void AlteraStatusMesa(int id, string status_mesa);
        List<Pedido> BuscaPedido(int id);
        void AlteraStatusPedido(int id, string status_pedido);
        void AdicionaPedido(PedidoRequest pedidoRequest);
    }
}