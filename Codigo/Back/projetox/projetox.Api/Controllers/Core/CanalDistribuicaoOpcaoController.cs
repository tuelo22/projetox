using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using projetox.Api.Controllers.Base;
using projetox.Domain.Core.DTO.Arguments;
using projetox.Domain.Core.Interfaces.Services;
using projetox.Repository.Transactions;

namespace projetox.Api.Controllers.Core
{
    /// <summary>
    /// Opções de canal de distribuição.
    /// </summary>
    /// <param name="unitOfWork"></param>
    /// <param name="_CanalDistribuicaoOpcaoService"></param>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CanalDistribuicaoOpcaoController(
        IUnitOfWork unitOfWork,
        ICanalDistribuicaoOpcaoService _CanalDistribuicaoOpcaoService) : ControllerAPIBase(unitOfWork)
    {

        /// <summary>
        /// Listar os canais de distribuição pré-cadastrados.
        /// </summary>
        /// <remarks>
        /// Listar os canais de distribuição pré-cadastrados.
        /// </remarks>
        [HttpGet("ListarTodos")]
        [ProducesResponseType(typeof(ListarCanalDistribuicaoOpcaoDTO), 200)]
        [ProducesResponseType(typeof(ListarCanalDistribuicaoOpcaoDTO), 400)]
        public IActionResult Listar()
        {
            try
            {
                var response = _CanalDistribuicaoOpcaoService.ListarTodos();

                return ResponseAPI(response, _CanalDistribuicaoOpcaoService);
            }
            catch (Exception ex)
            {
                return ResponseAPIException(ex);
            }
        }
    }
}
