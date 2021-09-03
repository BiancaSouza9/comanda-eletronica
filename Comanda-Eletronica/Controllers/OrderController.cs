using Comanda_Eletronica.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace Comanda_Eletronica.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class OrderController : ControllerBase
    {
        private ComandaEletronicaContext Context;

        private readonly ILogger<OrderController> _logger;

        public OrderController(ILogger<OrderController> logger, ComandaEletronicaContext _context)
        {
            _logger = logger;
            Context = _context;
        }

        [HttpGet]
        public IActionResult GetOrders()
        {
            return Ok(Context.Orders.Any());
        }
    }
}