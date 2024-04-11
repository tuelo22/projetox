using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using projetox.Domain.Base.DTO.Arguments;
using projetox.Domain.Core.DTO.Arguments;
using projetox.Domain.Core.DTO;
using projetox.Domain.Core.Interfaces.Services;
using projetox.Repository.Transactions;
using projetox.Api.Controllers.Base;
using Microsoft.AspNetCore.Authorization;

namespace projetox.Api.Controllers.Core
{
    /// <summary>
    /// Segmento do cliente.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Geral")]
    public class SegmentoClienteController(
        IUnitOfWork unitOfWork,
        ISegmentoClienteService _SegmentoClienteService) : ControllerAPIBase(unitOfWork)
    {
        /// <summary>
        /// Cadastrar segmento do cliente.
        /// </summary>
        /// <remarks>
        /// Cadastro de segmento do cliente.
        /// </remarks>
        /// <param name="IdUsuario">Identificador do Usuario.</param>
        /// <param name="dto">Dados do segmento do cliente.</param>
        [HttpPost("Cadastrar/{IdUsuario}")]
        [ProducesResponseType(typeof(ResponseBaseDTO), 200)]
        [ProducesResponseType(typeof(ResponseBaseDTO), 400)]
        public IActionResult Cadastrar(Guid IdUsuario, [FromBody] SegmentoClienteDTO dto)
        {
            try
            {
                var response = _SegmentoClienteService.Cadastrar(IdUsuario, dto);

                return ResponseAPI(response, _SegmentoClienteService);
            }
            catch (Exception ex)
            {
                return ResponseAPIException(ex);
            }
        }

        /// <summary>
        /// Listar segmento do cliente.
        /// </summary>
        /// <remarks>
        /// Listar segmento do cliente com base na proposta de valor.
        /// </remarks>
        /// <param name="IdUsuario">Identificador do Usuario.</param>
        /// <param name="IdPropostaValor">Identificador da proposta de valor.</param>
        [HttpGet("Listar/{IdUsuario}/{IdPropostaValor}")]
        [ProducesResponseType(typeof(ListarEmpresaResponseDTO), 200)]
        [ProducesResponseType(typeof(ListarEmpresaResponseDTO), 400)]
        public IActionResult Listar(Guid IdUsuario, Guid IdPropostaValor)
        {
            try
            {
                var response = _SegmentoClienteService.Listar(IdUsuario, IdPropostaValor);

                return ResponseAPI(response, _SegmentoClienteService);
            }
            catch (Exception ex)
            {
                return ResponseAPIException(ex);
            }
        }

        /// <summary>
        /// Deletar segmento do cliente.
        /// </summary>
        /// <remarks>
        /// Deletar segmento do cliente.
        /// </remarks>
        /// <param name="IdUsuario">Identificador do Usuario.</param>
        /// <param name="IdSegmentoCliente">Identificador do segmento do cliente.</param>
        [HttpDelete("Deletar/{IdUsuario}/{IdSegmentoCliente}")]
        [ProducesResponseType(typeof(ResponseBaseDTO), 200)]
        [ProducesResponseType(typeof(ResponseBaseDTO), 400)]
        public IActionResult Deletar(Guid IdUsuario, Guid IdSegmentoCliente)
        {
            try
            {
                var response = _SegmentoClienteService.Deletar(IdUsuario, IdSegmentoCliente);

                return ResponseAPI(response, _SegmentoClienteService);
            }
            catch (Exception ex)
            {
                return ResponseAPIException(ex);
            }
        }

        /// <summary>
        /// Atualizar segmento do cliente.
        /// </summary>
        /// <remarks>
        /// Atualizar segmento do cliente.
        /// </remarks>
        /// <param name="IdUsuario">Identificador do Usuario</param>
        /// <param name="dto">Dados do segmento do cliente.</param>
        [HttpPut("Atualizar/{IdUsuario}")]
        [ProducesResponseType(typeof(ResponseBaseDTO), 200)]
        [ProducesResponseType(typeof(ResponseBaseDTO), 400)]
        public IActionResult Atualizar(Guid IdUsuario, [FromBody] SegmentoClienteDTO dto)
        {
            try
            {
                var response = _SegmentoClienteService.Atualizar(IdUsuario, dto);

                return ResponseAPI(response, _SegmentoClienteService);
            }
            catch (Exception ex)
            {
                return ResponseAPIException(ex);
            }
        }

    }
}
