using Comanda_Eletronica.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Comanda_Eletronica.Entities.Enums;
using Comanda_Eletronica.Models;

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
        public IActionResult GetMesas(int id = 1)
        {   
            return Ok(Repository.GetMesas(id));
        }

        [HttpGet]
        public IActionResult GetProdutos(int id = 1)
        {
            return Ok(Repository.GetProdutos(id));
        }

        [HttpPost]
        public IActionResult SetMesa([FromBody] MesaRequest mesa)
        {
            Repository.SetMesa(mesa.Id, mesa.Status_Mesa);
            return Ok();
        }
    }    
}