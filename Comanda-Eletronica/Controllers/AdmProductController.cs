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
    public class AdmProductController : ControllerBase
    {
        private IAdmProductRepository Repository;

        private readonly ILogger<AdmProductController> _logger;

        public AdmProductController(ILogger<AdmProductController> logger, IAdmProductRepository repository)
        {
            _logger = logger;
            Repository = repository;
        }

        [HttpPost]
        public IActionResult AdicionaProduto([FromBody] ProdutoRequest produto)
        {
            Repository.AdicionaProduto(produto);
            return Ok("Produto Adicionado com Sucesso");
        }

        [HttpPost]
        public IActionResult RemoveProduto([FromBody] ProdutoRequest produto)
        {
            Repository.RemoveProduto(produto);
            return Ok("Produto Removido com Sucesso");
        }

        [HttpPost]
        public IActionResult AlteraProduto([FromBody] ProdutoRequest produto)
        {
            Repository.AlteraProduto(produto);
            return Ok("Produto Atualizado com Sucesso");
        }
    }    
}
