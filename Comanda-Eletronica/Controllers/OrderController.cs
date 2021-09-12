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

        [HttpGet]
        public IActionResult BuscaProdutos([FromQuery] ProdutoRequest produto)
        {
            Repository.BuscaProdutos(produto.IdProduto);
            return Ok();
        }

        [HttpGet]
        public IActionResult BuscaMesasLivres()
        {
            return Ok (Repository.BuscaMesasLivres());
        }

        [HttpPost]
        public IActionResult AlteraStatusMesa([FromQuery] MesaRequest mesa)
        {
            Repository.AlteraStatusMesa(mesa.IdMesa, mesa.IdStatus);
            return Ok("Status Alterado com Sucesso");
        }

        [HttpGet]
        public IActionResult BuscaPedido([FromBody] PedidoRequest pedido)
        {
            Repository.BuscaPedido(pedido.IdPedido);
            return Ok("Pedido: " + pedido.IdPedido);
        }

        [HttpPost]
        public IActionResult AlteraStatusPedido([FromQuery] PedidoRequest pedido)
        {
            Repository.AlteraStatusPedido(pedido.IdPedido, pedido.StatusPedido) ;
            return Ok("Status Alterado com Sucesso");
        }

        [HttpPost]
        public IActionResult AdicionaPedido([FromBody] PedidoRequest pedido)
        {
            Repository.AdicionaPedido(pedido);
            return Ok("Pedido Adicionado com Sucesso");
        }
    }
}