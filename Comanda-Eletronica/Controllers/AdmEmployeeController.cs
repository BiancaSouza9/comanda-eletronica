using Comanda_Eletronica.Models;
using Comanda_Eletronica.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Comanda_Eletronica.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class AdmEmployeeController : ControllerBase
    {
        private IAdmEmployeeRepository Repository;

        private readonly ILogger<AdmEmployeeController> _logger;

        public AdmEmployeeController(ILogger<AdmEmployeeController> logger, IAdmEmployeeRepository repository)
        {
            _logger = logger;
            Repository = repository;
        }

        [HttpPost]
        public IActionResult CriaFuncionario([FromBody] FuncionarioRequest funcionario)
        {
            Repository.CriaFuncionario(funcionario);
            return Ok("Funcionario Adicionado com Sucesso");
        }

        [HttpPost]
        public IActionResult RemoveFuncionario([FromBody] FuncionarioRequest funcionario)
        {
            Repository.RemoveFuncionario(funcionario);
            return Ok("Funcionário Removido com Sucesso");
        }

        [HttpPost]
        public IActionResult AlteraFuncionario([FromBody] FuncionarioRequest funcionario)
        {
            Repository.AlteraFuncionario(funcionario);
            return Ok("Funcionario Atualizado com Sucesso");
        }

        [HttpPost]
        public IActionResult ResetSenha([FromBody] FuncionarioRequest funcionario)
        {
            Repository.ResetSenha(funcionario);
            return Ok("Nova Senha Gerada com Sucesso");
        }
    }    
}
