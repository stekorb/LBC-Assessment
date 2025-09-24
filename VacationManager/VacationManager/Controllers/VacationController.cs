using Microsoft.AspNetCore.Mvc;
using System.Net;
using VacationManager.Common.Responses;
using VacationManager.Dto.Vacation;
using VacationManager.Services.Interfaces.Vacation;

namespace VacationManager.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VacationController : BaseController
    {
        private readonly IRetrieveAllVacationsSvc _retrieveAllVacationsSvc;
        private readonly IRetrieveEmployeeVacationsSvc _retrieveEmployeeVacationsSvc;

        public VacationController(IRetrieveAllVacationsSvc retrieveAllVacationsSvc, 
                                  IRetrieveEmployeeVacationsSvc retrieveEmployeeVacationsSvc)
        {
            _retrieveAllVacationsSvc = retrieveAllVacationsSvc;
            _retrieveEmployeeVacationsSvc = retrieveEmployeeVacationsSvc;

        }

        /// <summary>
        /// Retrieves all vacations.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(List<VacationDto>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(List<ErrorResponseModel>), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> RetrieveAllEmployees()
        {
            var result = await _retrieveAllVacationsSvc.Execute();
            return ReturnResponse(result);
        }

        /// <summary>
        /// Retrieves the vacations that an employee has registered.
        /// </summary>
        /// <param name="employeeId">Employee unique identifier</param>
        /// <returns></returns>
        [HttpGet("employeeId")]
        [ProducesResponseType(typeof(List<VacationDto>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(List<ErrorResponseModel>), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> RetrieveAllEmployees(Guid employeeId)
        {
            var result = await _retrieveEmployeeVacationsSvc.Execute(employeeId);
            return ReturnResponse(result);
        }
    }
}
