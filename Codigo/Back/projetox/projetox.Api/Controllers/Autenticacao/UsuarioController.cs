using Microsoft.AspNetCore.Mvc;
using projetox.Api.Controllers.Base;
using projetox.Domain.Autenticacao.DTO;
using projetox.Domain.Autenticacao.DTO.Arguments;
using projetox.Domain.Autenticacao.Interfaces.Services;
using projetox.Domain.Base.DTO.Arguments;
using projetox.Repository.Transactions;

namespace projetox.Api.Controllers.Autenticacao
{
    /// <summary>
    /// Controlador de usuarios nao autenticados
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController(
        IUnitOfWork unitOfWork,
        IRegistrarUsuarioService registrarUsuarioService,
        IResetarSenhaUsuario resetarSenhaUsuario,
        ITokenService tokenService) : ControllerAPIBase(unitOfWork)
    {
        private readonly IRegistrarUsuarioService _RegistrarUsuarioService = registrarUsuarioService;
        private readonly IResetarSenhaUsuario _ResetarSenhaUsuario = resetarSenhaUsuario;
        private readonly ITokenService _TokenService = tokenService;

        /// <summary>
        /// Cadastrar usuarios
        /// </summary>
        /// <remarks>
        /// Cadastro um novo usuario
        /// </remarks>
        /// <param name="usuario">Dados do usuario</param>
        [HttpPost("Cadastrar")]
        [ProducesResponseType(typeof(ResponseBaseDTO), 200)]
        [ProducesResponseType(typeof(ResponseBaseDTO), 400)]
        public IActionResult Cadastrar([FromBody] NovoUsuarioDTO usuario)
        {
            try
            {
                var response = _RegistrarUsuarioService.Registrar(usuario);

                return ResponseAPI(response, _RegistrarUsuarioService);
            }
            catch (Exception ex)
            {
                return ResponseAPIException(ex);
            }
        }

        /// <summary>
        /// Login
        /// </summary>
        /// <remarks>
        /// Autenticacao
        /// </remarks>
        /// <param name="dto">Dados de autenticacao</param>
        [HttpPost("login", Name ="login")]
        [ProducesResponseType(typeof(TokenDTO), 200)]
        [ProducesResponseType(typeof(ResponseBaseDTO), 400)]
        public IActionResult Login(LoginDTO dto)
        {
            try
            {
                var response = _TokenService.Gerar(dto);

                return ResponseAPI(response, _TokenService);
            }
            catch (Exception ex)
            {
                return ResponseAPIException(ex);
            }
        }

        /// <summary>
        /// Esqueci minha senha.
        /// </summary>
        /// <remarks>
        /// Reseta a senha do usuario e envia um email com a nova senha gerada dinamicamente. 
        /// </remarks>
        /// <param name="email">E-mail do usuario.</param>
        [HttpPost("EsqueciMinhaSenha")]
        [ProducesResponseType(typeof(ResponseBaseDTO), 200)]
        [ProducesResponseType(typeof(ResponseBaseDTO), 400)]
        public IActionResult EsqueciMinhaSenha(string email)
        {
            try
            {
                var response = _ResetarSenhaUsuario.Resetar(email);

                return ResponseAPI(response, _ResetarSenhaUsuario);
            }
            catch (Exception ex)
            {
                return ResponseAPIException(ex);
            }
        }
    }
}
