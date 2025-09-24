using AutoMapper;
using VacationManager.Common.Responses;
using VacationManager.Dto.Employee;
using VacationManager.Repositories.Interfaces;
using VacationManager.Services.Interfaces.Employee;

namespace VacationManager.Services.Employee
{
    public class RetrieveManagedEmployeesSvc : BaseService, IRetrieveManagedEmployeesSvc
    {
        private readonly IEmployeeRepo _employeeRepo;

        public RetrieveManagedEmployeesSvc(IEmployeeRepo employeeRepo, IMapper mapper) : base(mapper)
        {
            _employeeRepo = employeeRepo;
        }

        public async Task<ResponseModel<List<EmployeeDto>>> Execute(Guid managerId)
        {
            ResponseModel<List<EmployeeDto>> result = new ResponseModel<List<EmployeeDto>>();

            var model = await _employeeRepo.RetrieveManagedEmployees(managerId);
            result.Result = _mapper.Map<List<EmployeeDto>>(model);

            return result;
        }
    }
}
