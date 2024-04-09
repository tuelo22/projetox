using Microsoft.AspNetCore.Mvc;
using projetox.Domain.Base.DTO.Arguments;
using projetox.Domain.Base.Interfaces.Services;
using projetox.Repository.Transactions;

namespace projetox.Api.Controllers.Base
{
    /// <summary>
    /// Classe controller basica, todo controlle deve herdade dela.
    /// </summary>
    public class ControllerAPIBase(IUnitOfWork _unitOfWork) : ControllerBase
    {
        /// <summary>
        /// Método de resposta padrão.
        /// </summary>
        protected IActionResult ResponseAPI(ResponseBaseDTO result, IServiceBase serviceBase)
        {
            result.Mensagens = serviceBase.GetMensagensDTO();

            if (serviceBase.Valido())
            {
                try
                {
                    _unitOfWork.Commit();

                    return Ok(result);
                }
                catch (Exception ex)
                {
                    return ResponseAPIException(ex);
                }
            }
            else
            {
                return BadRequest(result);
            }
        }

        /// <summary>
        /// Response em caso de excessão.
        /// </summary>
        protected IActionResult ResponseAPIException(Exception ex)
        {
            return StatusCode(500, new { errors = $"Houve um problema interno com o servidor. Entre em contato com o Administrador do sistema caso o problema persista. Erro interno: {ex.Message}", exception = ex.ToString() });
        }
    }
}
