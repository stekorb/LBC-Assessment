using Microsoft.AspNetCore.Mvc;
using VacationManager.Common.Responses;

namespace VacationManager.Controllers
{
    public class BaseController : ControllerBase
    {
        protected IActionResult ReturnResponse<T>(ResponseModel<T> response)
        {
            if(response.HasErrors)
            {
                return BadRequest(response.Errors);
            }

            return Ok(response.Result);
        }
    }
}
