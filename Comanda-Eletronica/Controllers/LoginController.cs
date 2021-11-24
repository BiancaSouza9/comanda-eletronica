using Comanda_Eletronica.Filters;
using Comanda_Eletronica.Models;
using Comanda_Eletronica.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Comanda_Eletronica.Controllers
{
    [ApiController]
    [ApiKeyAuth]
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

        [HttpPost]
        public IActionResult Login([FromBody] LoginRequest funcionario)
        {
            var retorno = Repository.GetLogin(funcionario.Usuario, funcionario.Senha);

            if (retorno != null)
            {
                int funcionarioId = retorno.id_funcionario_pk;

                return Ok(new { Mensagem = "Login Realizado com Sucesso ", FuncionarioId = funcionarioId });
            }
            else
            {
                return StatusCode(401, "Usuário ou Senha inválidos");
            }
        }
    }
}