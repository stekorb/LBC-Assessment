using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using VacationManager.Common.Enums;
using VacationManager.Common.Responses;
using VacationManager.Dto.Employee;
using VacationManager.Services.Interfaces.Employee;

namespace VacationManager.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : BaseController
    {
        private readonly IRetrieveAllEmployeesSvc _retrieveAllEmployeesSvc;
        private readonly ICreateEmployeeSvc _createEmployeeSvc;
        private readonly IUpdateEmployeeSvc _updateEmployeeSvc;
        private readonly IDeleteEmployeeSvc _deleteEmployeeSvc;
        private readonly IRetrieveManagedEmployeesSvc _retrieveManagedEmployeesSvc;
        public EmployeeController(IRetrieveAllEmployeesSvc retrieveAllEmployeesSvc, 
                                  ICreateEmployeeSvc createEmployeeSvc,
                                  IUpdateEmployeeSvc updateEmployeeSvc,
                                  IDeleteEmployeeSvc deleteEmployeeSvc,
                                  IRetrieveManagedEmployeesSvc retrieveManagedEmployeesSvc)
        {
            _retrieveAllEmployeesSvc = retrieveAllEmployeesSvc;
            _createEmployeeSvc = createEmployeeSvc;
            _updateEmployeeSvc = updateEmployeeSvc;
            _deleteEmployeeSvc = deleteEmployeeSvc;
            _retrieveManagedEmployeesSvc = retrieveManagedEmployeesSvc;
        }

        /// <summary>
        /// Retrieves all employees.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize(Roles = Roles.Administrator)]
        [ProducesResponseType(typeof(List<List<EmployeeDto>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(List<ErrorResponseModel>), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> RetrieveAllEmployees()
        {
            var result = await _retrieveAllEmployeesSvc.Execute();
            return ReturnResponse(result);
        }

        /// <summary>
        /// Retrieves all employees under the manager's.
        /// </summary>
        /// <param name="managerId">Manager's employee unique identifier</param>
        /// <returns></returns>
        [HttpGet("management/{managerId}")]
        [Authorize(Roles = $"{Roles.Manager}, {Roles.Administrator}")]
        [ProducesResponseType(typeof(List<List<EmployeeDto>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(List<ErrorResponseModel>), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> RetrieveManagedEmployees(Guid managerId)
        {
            var result = await _retrieveManagedEmployeesSvc.Execute(managerId);
            return ReturnResponse(result);
        }

        /// <summary>
        /// Creates a new employee.
        /// </summary>
        /// <param name="dto">Employee object to be created</param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Roles = Roles.Administrator)]
        [ProducesResponseType(typeof(List<bool>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(List<ErrorResponseModel>), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreateEmployee([FromBody] EmployeeCreateDto dto)
        {
            var result = await _createEmployeeSvc.Execute(dto);
            return ReturnResponse(result);
        }

        /// <summary>
        /// Updates an existing employee.
        /// </summary>
        /// <param name="dto">Employee object to be updated</param>
        /// <returns></returns>
        [HttpPatch]
        [Authorize(Roles = Roles.Administrator)]
        [ProducesResponseType(typeof(List<bool>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(List<ErrorResponseModel>), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> UpdateEmployee([FromBody] EmployeeDto dto)
        {
            var result = await _updateEmployeeSvc.Execute(dto);
            return ReturnResponse(result);
        }

        /// <summary>
        /// Deletes an existing employee.
        /// </summary>
        /// <param name="employeeId">Employee unique identifier</param>
        /// <returns></returns>
        [HttpDelete("{employeeId}")]
        [Authorize(Roles = Roles.Administrator)]
        [ProducesResponseType(typeof(List<bool>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(List<ErrorResponseModel>), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> DeleteEmployee(Guid employeeId)
        {
            var result = await _deleteEmployeeSvc.Execute(employeeId);
            return ReturnResponse(result);
        }
    }
}
