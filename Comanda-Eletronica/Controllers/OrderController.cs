using Comanda_Eletronica.Filters;
using Comanda_Eletronica.Models;
using Comanda_Eletronica.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace Comanda_Eletronica.Controllers
{
    [ApiController]
    [ApiKeyAuth]
    [Authorize]
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

        [HttpGet(template:"order")]
        public IActionResult GetSecret()
        {
            return Ok();
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
        public IActionResult CriaPedido([FromBody] PedidoRequest pedidoRequest)
        {
            int novoPedidoId = Repository.CriaPedido(pedidoRequest.IdMesa, pedidoRequest);
            return Ok( new { Mensagem = "Pedido Criado com Sucesso. ", PedidoId = novoPedidoId } );
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
            var itensResponse = retorno.itens.Select(i => new ItemResponse()
            {
                id_item_pk = i.id_item_pk,
                id_pedido_fk = i.id_pedido_fk,
                id_produto_fk = i.id_produto_fk,
                quantidade = i.quantidade,
                valor = i.valor,
                nomeProduto = i.produto.produto
            });
            var pedidoResponse = new PedidoResponse()
            {
                id_pedido_pk = retorno.id_pedido_pk,
                data = retorno.data,
                id_funcionario_fk = retorno.id_funcionario_fk,
                id_mesa_fk = retorno.id_mesa_fk,
                id_status_ped_fk = retorno.id_status_ped_fk,
                itens = itensResponse.ToList()
            };
            int pedidoId = retorno.id_pedido_pk;

            return Ok(new { Mensagem = "Pedido Encontrado. ", PedidoId = pedidoId, pedidoResponse });
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