using Comanda_Eletronica.Data;
using Comanda_Eletronica.Entities;
using Comanda_Eletronica.Entities.Enums;
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
            return Context.Mesa.Where(p => p.Id == id).ToList();
        }
        public void SetMesa(int id, string status_mesa)
        {
            Context.Mesa.Find(id).Status_Mesa = Enum.Parse<MesaStatus>(status_mesa);
            Context.SaveChanges();
        }
    }
}