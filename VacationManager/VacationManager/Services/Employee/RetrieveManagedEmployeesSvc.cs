using AutoMapper;
using VacationManager.Common.Enums;
using VacationManager.Common.Responses;
using VacationManager.Dto.Employee;
using VacationManager.Models;
using VacationManager.Repositories.Interfaces;
using VacationManager.Services.Interfaces.Authentication;
using VacationManager.Services.Interfaces.Employee;

namespace VacationManager.Services.Employee
{
    public class RetrieveManagedEmployeesSvc : BaseService, IRetrieveManagedEmployeesSvc
    {
        private readonly IEmployeeRepo _employeeRepo;
        private readonly IUserContextSvc _userContext;

        public RetrieveManagedEmployeesSvc(IEmployeeRepo employeeRepo, IUserContextSvc userContext, IMapper mapper) : base(mapper)
        {
            _employeeRepo = employeeRepo;
            _userContext = userContext;
        }

        public async Task<ResponseModel<List<EmployeeDto>>> Execute()
        {
            ResponseModel<List<EmployeeDto>> result = new ResponseModel<List<EmployeeDto>>();

            var model = new List<EmployeeModel>();
            if (_userContext.Role == RoleEnum.Administrator)
            {
                model = await _employeeRepo.RetrieveAllEmployees();
            }
            else
            {
                model = await _employeeRepo.RetrieveManagedEmployees(_userContext.UserId);
            }
            result.Result = _mapper.Map<List<EmployeeDto>>(model);

            return result;
        }
    }
}
