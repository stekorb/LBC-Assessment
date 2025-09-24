using Microsoft.AspNetCore.Mvc;
using System.Net;
using VacationManager.Common.Responses;
using VacationManager.Dto.Employee;
using VacationManager.Services.Interfaces.Employee;

namespace VacationManager.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : BaseController
    {
        private readonly IRetrieveAllEmployeesSvc _retrieveAllEmployeesSvc;
        private readonly ICreateEmployeeSvc _createEmployeeSvc;
        private readonly IUpdateEmployeeSvc _updateEmployeeSvc;

        public EmployeeController(IRetrieveAllEmployeesSvc retrieveAllEmployeesSvc, 
                                  ICreateEmployeeSvc createEmployeeSvc,
                                  IUpdateEmployeeSvc updateEmployeeSvc)
        {
            _retrieveAllEmployeesSvc = retrieveAllEmployeesSvc;
            _createEmployeeSvc = createEmployeeSvc;
            _updateEmployeeSvc = updateEmployeeSvc;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<List<EmployeeDto>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(List<ErrorResponseModel>), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> RetrieveAllEmployees()
        {
            var result = await _retrieveAllEmployeesSvc.Execute();
            return ReturnResponse(result);
        }

        [HttpPost]
        [ProducesResponseType(typeof(List<bool>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(List<ErrorResponseModel>), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreateEmployee(EmployeeCreateDto dto)
        {
            var result = await _createEmployeeSvc.Execute(dto);
            return ReturnResponse(result);
        }

        [HttpPatch]
        [ProducesResponseType(typeof(List<bool>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(List<ErrorResponseModel>), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> UpdateEmployee(EmployeeDto dto)
        {
            var result = await _updateEmployeeSvc.Execute(dto);
            return ReturnResponse(result);
        }
    }
}
