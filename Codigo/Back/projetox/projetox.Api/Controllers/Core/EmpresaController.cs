using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using projetox.Api.Controllers.Base;
using projetox.Domain.Base.DTO.Arguments;
using projetox.Domain.Core.DTO;
using projetox.Domain.Core.DTO.Arguments;
using projetox.Domain.Core.Interfaces.Services;
using projetox.Repository.Transactions;

namespace projetox.Api.Controllers.Core
{
    /// <summary>
    /// Empresa
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Geral")]
    public class EmpresaController(
        IUnitOfWork unitOfWork, IEmpresaService _EmpresaService) 
        : ControllerAPIBase(unitOfWork)
    {
        /// <summary>
        /// Cadastrar empresa
        /// </summary>
        /// <remarks>
        /// Cadastro da empresa
        /// </remarks>
        /// <param name="IdUsuario">Identificador do Usuario</param>
        /// <param name="dto">Dados da empresa</param>
        [HttpPost("Cadastrar/{IdUsuario}")]
        [ProducesResponseType(typeof(ResponseBaseDTO), 200)]
        [ProducesResponseType(typeof(ResponseBaseDTO), 400)]
        public IActionResult Cadastrar(Guid IdUsuario, [FromBody] EmpresaDTO dto)
        {
            try
            {
                var response = _EmpresaService.Cadastrar(IdUsuario ,dto);

                return ResponseAPI(response, _EmpresaService);
            }
            catch (Exception ex)
            {
                return ResponseAPIException(ex);
            }
        }

        /// <summary>
        /// Listar empresas do usuario
        /// </summary>
        /// <remarks>
        /// Listar empresas do usuario
        /// </remarks>
        /// <param name="IdUsuario">Identificador do Usuario</param>
        [HttpGet("Listar/{IdUsuario}")]
        [ProducesResponseType(typeof(ListarEmpresaResponseDTO), 200)]
        [ProducesResponseType(typeof(ListarEmpresaResponseDTO), 400)]
        public IActionResult Listar(Guid IdUsuario)
        {
            try
            {
                var response = _EmpresaService.Listar(IdUsuario);

                return ResponseAPI(response, _EmpresaService);
            }
            catch (Exception ex)
            {
                return ResponseAPIException(ex);
            }
        }

        /// <summary>
        /// Deletar empresa
        /// </summary>
        /// <remarks>
        /// Deletar empresa
        /// </remarks>
        /// <param name="IdUsuario">Identificador do Usuario</param>
        /// <param name="IdEmpresa">Identificador da Empresa</param>
        [HttpDelete("Deletar/{IdUsuario}/{IdEmpresa}")]
        [ProducesResponseType(typeof(ResponseBaseDTO), 200)]
        [ProducesResponseType(typeof(ResponseBaseDTO), 400)]
        public IActionResult Deletar(Guid IdUsuario, Guid IdEmpresa)
        {
            try
            {
                var response = _EmpresaService.Deletar(IdUsuario, IdEmpresa);

                return ResponseAPI(response, _EmpresaService);
            }
            catch (Exception ex)
            {
                return ResponseAPIException(ex);
            }
        }

        /// <summary>
        /// Atualizar empresa
        /// </summary>
        /// <remarks>
        /// Atualizar da empresa
        /// </remarks>
        /// <param name="IdUsuario">Identificador do Usuario</param>
        /// <param name="dto">Dados da empresa</param>
        [HttpPut("Atualizar/{IdUsuario}")]
        [ProducesResponseType(typeof(ResponseBaseDTO), 200)]
        [ProducesResponseType(typeof(ResponseBaseDTO), 400)]
        public IActionResult Atualizar(Guid IdUsuario, [FromBody] EmpresaDTO dto)
        {
            try
            {
                var response = _EmpresaService.Atualizar(IdUsuario, dto);

                return ResponseAPI(response, _EmpresaService);
            }
            catch (Exception ex)
            {
                return ResponseAPIException(ex);
            }
        }

    }
}
