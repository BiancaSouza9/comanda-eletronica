using Comanda_Eletronica.Data;
using Comanda_Eletronica.Models;
using Comanda_Eletronica.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Services.Comanda_Eletronica
{
    public class OrderService : IOrderService
    {
        private ComandaEletronicaContext Context;
        public OrderService(ComandaEletronicaContext context)
        {
            Context = context;
        }
        public List<Product> GetProducts()
        {
            return Context.Products.Where(p=>p.ProductName == "Bone").ToList();
        }
        public List<Produto> GetProdutos()
        {
            return Context.Produto.Where(p => p.Nome_Produto == "Pizza").ToList();
        }
        public List<Mesa> GetMesas()
        {
            return Context.Mesa.Where(p => p.Status_Mesa == 0).ToList();
        }
    }
}
