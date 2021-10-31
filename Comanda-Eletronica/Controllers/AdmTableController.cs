using Comanda_Eletronica.Models;
using Comanda_Eletronica.Repositories.Interfaces;
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
    public class AdmTableController : ControllerBase
    {
        private IAdmTableRepository Repository;

        private readonly ILogger<AdmTableController> _logger;

        public AdmTableController(ILogger<AdmTableController> logger, IAdmTableRepository repository)
        {
            _logger = logger;
            Repository = repository;
        }

        [HttpPost]
        public IActionResult AdicionaMesa([FromBody] MesaRequest mesaRequest)
        {
            Repository.AdicionaMesa(mesaRequest.Quantidade);
            return Ok("Mesa Adicionada com Sucesso");
        }

        [HttpPost]
        public IActionResult RemoveMesa([FromBody] MesaRequest mesa)
        {
            Repository.RemoveMesa(mesa);
            return Ok("Mesa Removida com Sucesso");
        }
    }
}