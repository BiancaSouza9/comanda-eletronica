using Comanda_Eletronica.Data;
using Comanda_Eletronica.Entities;
using Comanda_Eletronica.Entities.Enums;
using Comanda_Eletronica.Models;
using Comanda_Eletronica.Repositories.Interfaces;
using System;

namespace Comanda_Eletronica.Repositories
{
    public class AdmProductRepository : IAdmProductRepository
    {
        private ComandaEletronicaContext Context;
        public AdmProductRepository(ComandaEletronicaContext context)
        {
            Context = context;
        }

        public void AdicionaProduto(ProdutoRequest produtoRequest)
        {
            var produto = new Produto()
            {
                id_categoria_fk = Enum.Parse <Categoria> (produtoRequest.Categoria),
                produto = produtoRequest.Produto,
                valor = produtoRequest.Valor
            };
            Context.Produto.Add(produto);
            Context.SaveChanges();
        }

        public void RemoveProduto(ProdutoRequest produtoRequest)
        {
            var produto = Context.Produto.Find(produtoRequest.IdProduto);
            Context.Produto.Remove(produto);
            Context.SaveChanges();
        }

        public void AlteraProduto(ProdutoRequest produtoRequest)
        {
            var produto = Context.Produto.Find(produtoRequest.IdProduto);

            if (!string.IsNullOrEmpty (produtoRequest.Produto))
            {
                produto.produto = produtoRequest.Produto;
            }
            
            if(produtoRequest.Valor != 0)
            {
                produto.valor = produtoRequest.Valor;
            }
            
            if(!string.IsNullOrEmpty(produtoRequest.Categoria))
            {
                produto.id_categoria_fk = Enum.Parse<Categoria>(produtoRequest.Categoria);
            }
            
            Context.SaveChanges();
        }
    }
}
