using Comanda_Eletronica.Models;
using Comanda_Eletronica.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace Comanda_Eletronica.Controllers
{
    [ApiController]
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
        public IActionResult GetMesas([FromQuery] MesaRequest mesa)
        {
            Repository.GetMesas(mesa.id_mesa_pk);
            return Ok();
        }

        [HttpGet]
        public IActionResult GetProdutos([FromQuery] ProdutoRequest produto)
        {
            Repository.GetProdutos(produto.Id);
            return Ok();
        }

        [HttpGet]
        public IActionResult GetPedido([FromQuery] PedidoRequest pedido)
        {
            Repository.GetPedido(pedido.IdPedido);
            return Ok();
        }

        [HttpPost]
        public IActionResult SetMesa([FromQuery] MesaRequest mesa)
        {
            Repository.SetMesa(mesa.id_mesa_pk, mesa.id_status_fk);
            return Ok("Status Alterado com Sucesso");
        }

        [HttpPost]
        public IActionResult AddPedido([FromBody] PedidoRequest pedido)
        {
            Repository.AddPedido(pedido);
            return Ok("Pedido Adicionado com Sucesso");
        }
    }
}