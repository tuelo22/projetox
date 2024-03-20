using Microsoft.AspNetCore.Mvc;
using projetox.Api.Controllers.Base;
using projetox.Domain.Autenticacao.DTO.Arguments.Usuario;
using projetox.Domain.Autenticacao.Entidades;
using projetox.Domain.Autenticacao.Interfaces.Service;
using projetox.Repository.Transactions;

namespace projetox.Api.Controllers.Autenticacao
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerAPIBase
    {
        private readonly IRegistrarUsuarioService _RegistrarUsuarioService;
        private readonly IResetarSenhaUsuario _ResetarSenhaUsuario;
        private readonly ITokenService _TokenService;

        public UsuarioController(
            IUnitOfWork unitOfWork, 
            IRegistrarUsuarioService registrarUsuarioService, 
            IResetarSenhaUsuario resetarSenhaUsuario, 
            ITokenService tokenService) : base(unitOfWork)
        {
            _RegistrarUsuarioService = registrarUsuarioService;
            _ResetarSenhaUsuario = resetarSenhaUsuario;
            _TokenService = tokenService;
        }

        [HttpPost("Cadastrar")]
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

        [HttpPost("login", Name ="login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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

        [HttpPost("EsqueciMinhaSenha")]
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
