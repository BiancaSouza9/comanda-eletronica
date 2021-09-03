using Comanda_Eletronica.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Comanda_Eletronica.Services.Interfaces
{
    public interface IOrderService
    {
        List<Product>GetProducts();
        List<Produto> GetProdutos();
        List<Mesa> GetMesas();
    }
}
