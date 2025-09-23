using Microsoft.AspNetCore.Mvc;
using VacationManager.Common.Responses;
using VacationManager.Dto.Employee;
using VacationManager.Services.Interfaces;

namespace VacationManager.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController
    {
        private readonly IRetrieveAllEmployeesSvc _retrieveAllEmployeesSvc;
        private readonly ICreateEmployeeSvc _createEmployeeSvc;
        public EmployeeController(IRetrieveAllEmployeesSvc retrieveAllEmployeesSvc, ICreateEmployeeSvc createEmployeeSvc)
        {
            _retrieveAllEmployeesSvc = retrieveAllEmployeesSvc;
            _createEmployeeSvc = createEmployeeSvc;
        }

        [HttpGet]
        public ResponseModel<List<EmployeeDto>> RetrieveAllEmployees()
        {
            var result = _retrieveAllEmployeesSvc.Execute();
            return result;
        }

        [HttpPost]
        public ResponseModel<bool> CreateEmployee(EmployeeCreateDto dto)
        {
            return _createEmployeeSvc.Execute(dto);
        }
    }
}
