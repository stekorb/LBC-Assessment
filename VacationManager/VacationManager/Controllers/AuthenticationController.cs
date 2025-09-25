using Microsoft.AspNetCore.Mvc;
using System.Net;
using VacationManager.Common.Responses;
using VacationManager.Services.Interfaces.Authentication;

namespace VacationManager.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthenticationController : BaseController
    {
        private readonly IAuthenticationSvc _authSvc;

        public AuthenticationController(IAuthenticationSvc authSvc)
        {
            _authSvc = authSvc;
        }

        /// <summary>
        /// Authenticates the employee to use the application
        /// </summary>
        /// <param name="email">Employee's email</param>
        /// <param name="pwd">Emplyee's password</param>
        /// <returns>User token</returns>
        [HttpGet]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(List<ErrorResponseModel>), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Authenticate(string email, string pwd)
        {
            var result = await _authSvc.Authenticate(email, pwd);
            return ReturnResponse(result);
        }
    }
}
