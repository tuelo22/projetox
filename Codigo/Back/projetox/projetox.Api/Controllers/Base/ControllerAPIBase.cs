using Microsoft.AspNetCore.Mvc;
using projetox.Domain.Base.DTO.Arguments;
using projetox.Domain.Base.Interfaces.Service;
using projetox.Repository.Transactions;

namespace projetox.Api.Controllers.Base
{
    public class ControllerAPIBase : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ControllerAPIBase(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
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

        protected IActionResult ResponseAPIException(Exception ex)
        {
            return StatusCode(500, new { errors = $"Houve um problema interno com o servidor. Entre em contato com o Administrador do sistema caso o problema persista. Erro interno: {ex.Message}", exception = ex.ToString() });
        }
    }
}
