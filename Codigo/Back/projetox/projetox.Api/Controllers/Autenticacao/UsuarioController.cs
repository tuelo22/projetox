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

        public UsuarioController(IUnitOfWork unitOfWork, IRegistrarUsuarioService registrarUsuarioService, IResetarSenhaUsuario resetarSenhaUsuario) 
            : base(unitOfWork)
        {
            _RegistrarUsuarioService = registrarUsuarioService;
            _ResetarSenhaUsuario = resetarSenhaUsuario;
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
