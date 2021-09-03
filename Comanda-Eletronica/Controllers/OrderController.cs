using Comanda_Eletronica.Data;
using Comanda_Eletronica.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services.Comanda_Eletronica;
using System.Linq;

namespace Comanda_Eletronica.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class OrderController : ControllerBase
    {
        private IOrderService Service;

        private readonly ILogger<OrderController> _logger;

        public OrderController(ILogger<OrderController> logger, IOrderService service)
        {
            _logger = logger;
            Service = service;
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            return Ok(Service.GetProducts());
        }

        [HttpGet]
        public IActionResult GetMesas()
        {
            return Ok(Service.GetMesas());
        }

        [HttpGet]
        public IActionResult GetProdutos()
        {
            return Ok(Service.GetProdutos());
        }
    }
}