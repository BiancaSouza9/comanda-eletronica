using Comanda_Eletronica.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Comanda_Eletronica.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class PedidoController : ControllerBase
    {
        private ComandaEletronicaContext Context;

        private readonly ILogger<PedidoController> _logger;

        public PedidoController(ILogger<PedidoController> logger, ComandaEletronicaContext _context)
        {
            _logger = logger;
            Context = _context;
        }
 
        [HttpGet]
        public IActionResult GetProducts()
        {
            return Ok(Context.Products.Any());
        }
    }
}