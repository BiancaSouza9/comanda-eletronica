using Comanda_Eletronica.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Comanda_Eletronica.Repositories.Interfaces
{
    public interface IAdmProductRepository
    {
        void AdicionaProduto(ProdutoRequest produtoRequest);
        void RemoveProduto(ProdutoRequest produtoRequest);
        void AlteraProduto(ProdutoRequest produtoRequest);
    }
}