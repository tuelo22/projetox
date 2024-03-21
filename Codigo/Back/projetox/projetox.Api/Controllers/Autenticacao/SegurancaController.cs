using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using projetox.Api.Controllers.Base;
using projetox.Repository.Transactions;

namespace projetox.Api.Controllers.Autenticacao
{
    /// <summary>
    /// Alteracao de dados de seguranca do usuario
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles="Geral")]
    public class SegurancaController(IUnitOfWork unitOfWork) : ControllerAPIBase(unitOfWork)
    {
        /// <summary>
        /// Alteracao de senha.
        /// </summary>
        /// <remarks>
        /// Altera a senha do usuario
        /// </remarks>
        /// <param name="idUsuario">Identificador</param>
        /// <param name="senhaAtual">Senha atual</param>
        /// <param name="senhaNova">Nova senha</param>
        /// <param name="senhaNova2">Repeticao da nova senha</param>
        [HttpPut("AlterarSenha/{idUsuario}/{senhaAtual}/{senhaNova}/{senhaNova2}")]
        public IActionResult AlterarSenha(Guid idUsuario, string senhaAtual, string senhaNova, string senhaNova2)
        {
            return Ok();
        }

        /// <summary>
        /// Alteracao de e-mail.
        /// </summary>
        /// <remarks>
        /// Altera o email do usuario e envia um e-mail de confirmação antes de aceitar a mudanca.
        /// </remarks>
        /// <param name="idUsuario">Identificador</param>
        /// <param name="novoEmail">Senha atual</param>
        [HttpPut("AlterarEmail/{idUsuario}/{novoEmail}")]
        public IActionResult AlterarEmail(Guid idUsuario, string novoEmail)
        {
            return Ok();
        }

        /// <summary>
        /// Reenvia a confirmacao de e-mail
        /// </summary>
        /// <remarks>
        /// Reenvia ao novo email a mensagem de confirmacao.
        /// </remarks>
        /// <param name="idUsuario">Reenvia o email de confirmacao</param>
        [HttpPut("ConfirmarEmail/{idUsuario}")]
        public IActionResult ReenviaConfirmarEmail(Guid idUsuario)
        {
            return Ok("Funciona");
        }

        /// <summary>
        /// Confirma e-mail
        /// </summary>
        /// <remarks>
        /// Reenvia ao novo email a mensagem de confirmacao.
        /// </remarks>
        /// <param name="idUsuario">Identificador</param>
        /// <param name="email">Senha atual</param>
        /// <param name="codigo">Nova senha</param>
        [HttpPut("ConfirmarEmail/{idUsuario}/{email}/{codigo}")]
        public IActionResult ConfirmarEmail(Guid idUsuario, string email,string codigo)
        {
            return Ok("Funciona");
        }
    }
}
