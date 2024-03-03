using Microsoft.AspNetCore.Mvc;
using projetox.Domain.Base.Interfaces.Service;

namespace projetox.Api.Controllers.Base
{
    public class ControllerAPIBase : ControllerBase
    {
        public IActionResult ResponseAPI(object result, IServiceBase serviceBase)
        {
            if (serviceBase.Valido())
            {
                try
                {
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

        public IActionResult ResponseAPIException(Exception ex)
        {
            return StatusCode(500, new { errors = $"Houve um problema interno com o servidor. Entre em contato com o Administrador do sistema caso o problema persista. Erro interno: {ex.Message}", exception = ex.ToString()});
        }
    }
}
