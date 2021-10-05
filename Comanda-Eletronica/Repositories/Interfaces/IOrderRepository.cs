﻿using Comanda_Eletronica.Models;
using System.Collections.Generic;
using Comanda_Eletronica.Entities.Enums;
using Comanda_Eletronica.Entities;
using System;

namespace Comanda_Eletronica.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        List<Produto> BuscaProduto(string categoria);
        List<Mesa> BuscaMesasLivres();
        List<Mesa> BuscaMesasOcupadas();
        void AlteraStatusMesa(int id);
        Pedido BuscaPedido(int id);
        void AdicionaPedido(PedidoRequest pedidoRequest);
        void AdicionaItem(ItemRequest itemRequest, int idPedido);
        void EnviaPedido(int id);
        void EncerraPedido(int id);
    }
}