using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using projetox.Api.Controllers.Base;
using projetox.Domain.Core.DTO.Arguments;
using projetox.Domain.Core.Interfaces.Services;
using projetox.Repository.Transactions;

namespace projetox.Api.Controllers.Core
{
    /// <summary>
    /// Natureza jurídica.
    /// </summary>
    /// <param name="unitOfWork"></param>
    /// <param name="_NaturezaJuridicaService"></param>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class NaturezaJuridicaController(
        IUnitOfWork unitOfWork, 
        INaturezaJuridicaService _NaturezaJuridicaService) :  ControllerAPIBase(unitOfWork)
    {

        /// <summary>
        /// Listar todas as naturezas jurídicas.
        /// </summary>
        /// <remarks>
        /// Listar todas as naturezas jurídicas.
        /// </remarks>
        [HttpGet("ListarTodos")]
        [ProducesResponseType(typeof(ListarCanalDistribuicaoOpcaoDTO), 200)]
        [ProducesResponseType(typeof(ListarCanalDistribuicaoOpcaoDTO), 400)]
        public IActionResult ListarTodos()
        {
            try
            {
                var response = _NaturezaJuridicaService.ListarTodos();

                return ResponseAPI(response, _NaturezaJuridicaService);
            }
            catch (Exception ex)
            {
                return ResponseAPIException(ex);
            }
        }
    }
}
