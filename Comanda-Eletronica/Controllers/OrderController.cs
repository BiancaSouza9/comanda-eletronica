using Comanda_Eletronica.Models;
using Comanda_Eletronica.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace Comanda_Eletronica.Controllers
{
    [ApiController]
    //[Route("[controller]/[action]")]
    [Route("[controller]/[action]")]
    public class OrderController : ControllerBase
    {
        private IOrderRepository Repository;

        private readonly ILogger<OrderController> _logger;

        public OrderController(ILogger<OrderController> logger, IOrderRepository repository)
        {
            _logger = logger;
            Repository = repository;
        }

        [HttpPost]
        public IActionResult BuscaProduto([FromBody] ProdutoRequest produto)
        {
            return Ok(Repository.BuscaProduto(produto.Categoria));
        }

        [HttpGet]
        public IActionResult BuscaMesasLivres()
        {
            return Ok (Repository.BuscaMesasLivres());
        }

        [HttpGet]
        public IActionResult BuscaMesasOcupadas()
        {
            return Ok(Repository.BuscaMesasOcupadas());
        }

        [HttpPost]
        public IActionResult AlteraStatusMesa([FromBody] MesaRequest mesa)
        {
            Repository.AlteraStatusMesa(mesa.IdMesa);
            return Ok("Status Alterado com Sucesso");
        }

        [HttpPost]
        public IActionResult BuscaPedido([FromBody] PedidoRequest pedido)
        {
            var retorno = Repository.BuscaPedido(pedido.IdMesa);
            return Ok(retorno);
        }

        [HttpPost]
        public IActionResult AdicionaPedido([FromBody] PedidoRequest pedido)
        {
            Repository.AdicionaPedido(pedido);
            return Ok("Pedido Adicionado com Sucesso");
        }

        [HttpPost]
        public IActionResult AdicionaItem([FromBody] ItemRequest item)
        {
            Repository.AdicionaItem(item, item.IdPedido);
            return Ok("Item Adicionado com Sucesso");
        }

        [HttpPost]
        public IActionResult EnviaPedido([FromBody] PedidoRequest pedido)
        {
            Repository.EnviaPedido(pedido.IdPedido);
            return Ok("Pedido Enviado com Sucesso");
        }

        [HttpPost]
        public IActionResult EncerraPedido([FromBody] PedidoRequest pedido)
        {
            Repository.EncerraPedido(pedido.IdPedido);
            return Ok("Pedido Encerrado com Sucesso");
        }
    }
}