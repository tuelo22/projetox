using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using projetox.Api.Controllers.Base;
using projetox.Repository.Transactions;

namespace projetox.Api.Controllers.Autenticacao
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsuarioAutenticadoController : ControllerAPIBase
    {
        public UsuarioAutenticadoController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

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
