using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using projetox.Api.Controllers.Base;
using projetox.Domain.Base.DTO.Arguments;
using projetox.Domain.Core.DTO.Arguments;
using projetox.Domain.Core.DTO;
using projetox.Domain.Core.Interfaces.Services;
using projetox.Domain.Core.Services;
using projetox.Repository.Transactions;

namespace projetox.Api.Controllers.Core
{
    /// <summary>
    /// Proposta de valor.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class PropostaValorController(
        IUnitOfWork unitOfWork,
        IPropostaValorService _PropostaValorService) : ControllerAPIBase(unitOfWork)
    {
        /// <summary>
        /// Cadastrar proposta de valor
        /// </summary>
        /// <remarks>
        /// Cadastro de proposta de valor
        /// </remarks>
        /// <param name="IdUsuario">Identificador do Usuario</param>
        /// <param name="dto">Dados da proposta de valor</param>
        [HttpPost("Cadastrar/{IdUsuario}")]
        [ProducesResponseType(typeof(ResponseBaseDTO), 200)]
        [ProducesResponseType(typeof(ResponseBaseDTO), 400)]
        public IActionResult Cadastrar(Guid IdUsuario, [FromBody] PropostaValorDTO dto)
        {
            try
            {
                var response = _PropostaValorService.Cadastrar(IdUsuario, dto);

                return ResponseAPI(response, _PropostaValorService);
            }
            catch (Exception ex)
            {
                return ResponseAPIException(ex);
            }
        }

        /// <summary>
        /// Listar propostas de valor da empresa
        /// </summary>
        /// <remarks>
        /// Listar propostas de valor da empresa
        /// </remarks>
        /// <param name="IdUsuario">Identificador do Usuario</param>
        /// <param name="IdEmpresa">Identificador da Empresa</param>
        [HttpGet("Listar/{IdUsuario}/{IdEmpresa}")]
        [ProducesResponseType(typeof(ListarEmpresaResponseDTO), 200)]
        [ProducesResponseType(typeof(ListarEmpresaResponseDTO), 400)]
        public IActionResult Listar(Guid IdUsuario, Guid IdEmpresa)
        {
            try
            {
                var response = _PropostaValorService.Listar(IdUsuario, IdEmpresa);

                return ResponseAPI(response, _PropostaValorService);
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
        /// <param name="IdPropostaValor">Identificador da proposta de valor</param>
        [HttpDelete("Deletar/{IdUsuario}/{IdEmpresa}")]
        [ProducesResponseType(typeof(ResponseBaseDTO), 200)]
        [ProducesResponseType(typeof(ResponseBaseDTO), 400)]
        public IActionResult Deletar(Guid IdUsuario, Guid IdPropostaValor)
        {
            try
            {
                var response = _PropostaValorService.Deletar(IdUsuario, IdPropostaValor);

                return ResponseAPI(response, _PropostaValorService);
            }
            catch (Exception ex)
            {
                return ResponseAPIException(ex);
            }
        }

        /// <summary>
        /// Atualizar proposta de valor.
        /// </summary>
        /// <remarks>
        /// Atualizar proposta de valor.
        /// </remarks>
        /// <param name="IdUsuario">Identificador do Usuario</param>
        /// <param name="dto">Dados da proposta de valor</param>
        [HttpPut("Atualizar/{IdUsuario}")]
        [ProducesResponseType(typeof(ResponseBaseDTO), 200)]
        [ProducesResponseType(typeof(ResponseBaseDTO), 400)]
        public IActionResult Atualizar(Guid IdUsuario, [FromBody] PropostaValorDTO dto)
        {
            try
            {
                var response = _PropostaValorService.Atualizar(IdUsuario, dto);

                return ResponseAPI(response, _PropostaValorService);
            }
            catch (Exception ex)
            {
                return ResponseAPIException(ex);
            }
        }

    }
}
