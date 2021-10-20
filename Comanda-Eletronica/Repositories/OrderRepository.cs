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
            return Context.Produto.Where(p => p.id_categoria_fk == Enum.Parse <Categoria> (categoria)).ToList();
        }

        public List<Mesa> BuscaMesasLivres()
        {
            return Context.Mesa.Where(p => p.id_status_fk.Equals(MesaStatus.Livre)).ToList();
        }

        public List<Mesa> BuscaMesasOcupadas()
        {
            return Context.Mesa.Where(p => p.id_status_fk.Equals(MesaStatus.Ocupado)).ToList();
        }

        public void AlteraStatusMesa(int id)
        {
            Context.Mesa.Find(id).id_status_fk = Enum.Parse<MesaStatus>("Ocupado");
            Context.SaveChanges();
        }

        public Pedido BuscaPedido(int mesa)
        {
            return Context.Pedido.Where(p => p.id_mesa_fk == mesa 
                && (p.id_status_ped_fk == Enum.Parse<PedidoStatus>("Aberto") 
                || p.id_status_ped_fk == Enum.Parse<PedidoStatus>("Preparando")))
                .Include(p => p.itens).FirstOrDefault();
        }

        public void AdicionaPedido(PedidoRequest pedidoRequest)
        {
            var pedido = new Pedido()
            {
                id_mesa_fk = pedidoRequest.IdMesa,
                id_funcionario_fk = pedidoRequest.IdFuncionario,
                id_status_ped_fk = Enum.Parse<PedidoStatus>("Aberto"),
                data = DateTime.Now
            };

            pedido.itens = pedidoRequest.Itens.Select(i =>
                new Item()
                {
                    id_produto_fk = i.IdProduto,
                    quantidade = i.Quantidade,
                    valor = Context.Produto.Find(i.IdProduto).valor
                }).ToList();

            Context.Pedido.Add(pedido);

            Context.SaveChanges();
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