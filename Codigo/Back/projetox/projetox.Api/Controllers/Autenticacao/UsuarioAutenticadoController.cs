using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using projetox.Api.Controllers.Base;

namespace projetox.Api.Controllers.Autenticacao
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsuarioAutenticadoController : ControllerAPIBase
    {
        [HttpPut("AlterarSenha")]
        public IActionResult AlterarSenha(string senhaAtual, string senhaNova, string senhaNova2)
        {
            return Ok();
        }

        [HttpPut("AlterarEmail")]
        public IActionResult AlterarEmail(string novoEmail)
        {
            return Ok();
        }

        [HttpPut("ConfirmarEmail")]
        public IActionResult ConfirmarEmail(Guid idUsuario)
        {
            return Ok();
        }
    }
}
