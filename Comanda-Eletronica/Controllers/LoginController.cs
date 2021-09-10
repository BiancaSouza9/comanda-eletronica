using Comanda_Eletronica.Models;
using Comanda_Eletronica.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Comanda_Eletronica.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class LoginController : ControllerBase
    {
        private ILoginRepository Repository;

        private readonly ILogger<LoginController> _logger;

        public LoginController(ILogger<LoginController> logger, ILoginRepository repository)
        {
            _logger = logger;
            Repository = repository;
        }

        [HttpGet]
        public IActionResult GetLogin([FromQuery] LoginRequest funcionario)
        {
            var retorno = Repository.GetLogin(funcionario.Usuario, funcionario.Senha);

            if (retorno != null)
            {
                return Ok("Login OK");
            }
            else
            {
                return StatusCode(401, "Usuário ou Senha inválidos");
            }
        }
    }
}