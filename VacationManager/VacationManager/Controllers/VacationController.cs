using Microsoft.AspNetCore.Mvc;
using System.Net;
using VacationManager.Common.Enums;
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
        private readonly IRetrieveVacationSvc _retrieveVacationSvc;
        private readonly IRegisterNewVacationSvc _registerNewVacationSvc;
        private readonly IReviewVacationRequestSvc _reviewVacationRequestSvc;

        public VacationController(IRetrieveAllVacationsSvc retrieveAllVacationsSvc, 
                                  IRetrieveEmployeeVacationsSvc retrieveEmployeeVacationsSvc,
                                  IRetrieveVacationSvc retrieveVacationSvc,
                                  IRegisterNewVacationSvc registerNewVacationSvc,
                                  IReviewVacationRequestSvc reviewVacationRequestSvc)
        {
            _retrieveAllVacationsSvc = retrieveAllVacationsSvc;
            _retrieveEmployeeVacationsSvc = retrieveEmployeeVacationsSvc;
            _retrieveVacationSvc = retrieveVacationSvc;
            _registerNewVacationSvc = registerNewVacationSvc;
            _reviewVacationRequestSvc = reviewVacationRequestSvc;
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
        /// Retrieves a single vacation.
        /// </summary>
        /// <param name="vacationId">Vacation unique identifier</param>
        /// <returns></returns>
        [HttpGet("{vacationId}")]
        [ProducesResponseType(typeof(VacationDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(List<ErrorResponseModel>), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> RetrieveVacation(Guid vacationId)
        {
            var result = await _retrieveVacationSvc.Execute(vacationId);
            return ReturnResponse(result);
        }


        /// <summary>
        /// Retrieves all vacations registered for an employee.
        /// </summary>
        /// <param name="employeeId">Employee unique identifier</param>
        /// <returns></returns>
        [HttpGet("employee/{employeeId}")]
        [ProducesResponseType(typeof(List<VacationDto>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(List<ErrorResponseModel>), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> RetrieveEmployeeVacation(Guid employeeId)
        {
            var result = await _retrieveEmployeeVacationsSvc.Execute(employeeId);
            return ReturnResponse(result);
        }

        /// <summary>
        /// Registers a new vacation for an employee.
        /// </summary>
        /// <param name="dto">Vacation object to be created</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(List<ErrorResponseModel>), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> RegisterNewVacation([FromBody] VacationCreateDto dto)
        {
            var result = await _registerNewVacationSvc.Execute(dto);
            return ReturnResponse(result);
        }

        /// <summary>
        /// Allows to approve or reject an existing vacation request awaiting for review.
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPatch]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(List<ErrorResponseModel>), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> ReviewVacationRequest([FromBody] VacationReviewDto dto)
        {
            var result = await _reviewVacationRequestSvc.Execute(dto);
            return ReturnResponse(result);
        }
    }
}
