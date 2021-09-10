using Comanda_Eletronica.Data;
using Comanda_Eletronica.Entities;
using Comanda_Eletronica.Entities.Enums;
using Comanda_Eletronica.Models;
using Comanda_Eletronica.Repositories.Interfaces;
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

        public List<Produto> GetProdutos(int id)
        {
            return Context.Produto.Where(p => p.Id == id).ToList();
        }

        public List<Mesa> GetMesas(int id)
        {
            return Context.Mesa.Where(p => p.id_mesa_pk == id).ToList();
        }

        public void SetMesa(int id, string status_mesa)
        {
            Context.Mesa.Find(id).id_status_fk = Enum.Parse<MesaStatus>(status_mesa);
            Context.SaveChanges();
        }

        public List<Pedido> GetPedido(int id)
        {
            return Context.Pedido.Where(p => p.id_pedido_pk == id).ToList();
        }

        public void SetPedidoStatus(int id, string status_pedido)
        {
            Context.Pedido.Find(id).id_status_ped_fk = Enum.Parse<PedidoStatus>(status_pedido);
            Context.SaveChanges();
        }

        public void AddPedido(PedidoRequest pedidoRequest)
        {
            var pedido = new Pedido()
            {
                id_mesa_fk = pedidoRequest.IdMesa, 
                id_funcionario_fk = pedidoRequest.IdFuncionario, 
                id_status_ped_fk = Enum.Parse<PedidoStatus>(pedidoRequest.StatusPedido), 
                data = DateTime.Now
            };

            pedido.itens = pedidoRequest.Itens.Select(i =>
                new Item()
                {
                    id_produto_fk = i.IdProduto,
                    quantidade = i.Quantidade,
                    valor = i.Valor
                }).ToList();

            Context.Pedido.Add(pedido);

            Context.SaveChanges();
        }
    }
}