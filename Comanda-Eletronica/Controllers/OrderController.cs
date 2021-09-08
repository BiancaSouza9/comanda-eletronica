using Comanda_Eletronica.Models;
using Comanda_Eletronica.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

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
        public IActionResult GetMesas([FromBody] MesaRequest mesa)
        {
            Repository.GetMesas(mesa.Id);
            return Ok();
        }

        [HttpGet]
        public IActionResult GetProdutos([FromBody] ProdutoRequest produto)
        {
            Repository.GetProdutos(produto.Id);
            return Ok();
        }

        [HttpPost]
        public IActionResult SetMesa([FromBody] MesaRequest mesa)
        {
            Repository.SetMesa(mesa.Id, mesa.Status_Mesa);
            return Ok();
        }
    }    
}