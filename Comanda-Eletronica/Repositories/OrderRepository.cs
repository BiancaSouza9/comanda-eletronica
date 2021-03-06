using Comanda_Eletronica.Data;
using Comanda_Eletronica.Entities;
using Comanda_Eletronica.Entities.Enums;
using Comanda_Eletronica.Models;
using Comanda_Eletronica.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Comanda_Eletronica.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private ComandaEletronicaContext Context;
        public OrderRepository(ComandaEletronicaContext context)
        {
            Context = context;
        }

        public List<Produto> BuscaProduto(string categoria)
        {
            return Context.Produto.Where(p => p.id_categoria_fk == Enum.Parse <Categoria> (categoria) 
            && p.status.Equals(Status.Ativo)).ToList();
        }

        public List<Mesa> BuscaMesasLivres()
        {
            return Context.Mesa.Where(p => p.id_status_fk.Equals(MesaStatus.Livre)
            && p.status.Equals(Status.Ativo)).ToList();
        }

        public int CriaPedido(int idMesa, PedidoRequest pedidoRequest)
        {
            var pedido = new Pedido()
            {
                id_mesa_fk = idMesa,
                id_funcionario_fk = pedidoRequest.IdFuncionario,
                id_status_ped_fk = Enum.Parse<PedidoStatus>("Aberto"),
                data = DateTime.Now
            };

            Context.Mesa.Find(idMesa).id_status_fk = Enum.Parse<MesaStatus>("Ocupado");
            Context.Pedido.Add(pedido);
            Context.SaveChanges();

            return pedido.id_pedido_pk;

        }

        public List<Mesa> BuscaMesasOcupadas()
        {
            return Context.Mesa.Where(p => p.id_status_fk.Equals(MesaStatus.Ocupado)
            && p.status.Equals(Status.Ativo)).ToList();
        }

        public void AlteraStatusMesa(int id)
        {
            Context.Mesa.Find(id).id_status_fk = Enum.Parse<MesaStatus>("Ocupado");
            Context.SaveChanges();
        }

        public Pedido BuscaPedido(int mesa)
        {
            var pedido = Context.Pedido
            .Where(p => p.id_mesa_fk == mesa
                && (p.id_status_ped_fk == Enum.Parse<PedidoStatus>("Aberto") || 
                    p.id_status_ped_fk == Enum.Parse<PedidoStatus>("Preparando"))
                   )
            .Include(p => p.itens)
                .ThenInclude(x => x.produto)
            .FirstOrDefault();

            return pedido;
        }

        public void AdicionaItem(ItemRequest itemRequest, int idPedido)
        {
            var item = new Item()
            {
                id_produto_fk = itemRequest.IdProduto,
                quantidade = itemRequest.Quantidade,
                valor = Context.Produto.Find(itemRequest.IdProduto).valor,
                id_pedido_fk = idPedido
            };

            Context.Item.Add(item);
            Context.SaveChanges();
        }

        public void EnviaPedido(int id)
        {
            Context.Pedido.Find(id).id_status_ped_fk = Enum.Parse<PedidoStatus>("Preparando");
            Context.SaveChanges();
        }

        public void EncerraPedido(int id)
        {
            var pedido = Context.Pedido.Find(id);
            pedido.id_status_ped_fk = Enum.Parse<PedidoStatus>("Concluido");
            Context.Mesa.Find(pedido.id_mesa_fk).id_status_fk = Enum.Parse<MesaStatus>("Livre");
            Context.SaveChanges();
        }

    }
}