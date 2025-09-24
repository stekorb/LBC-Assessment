using AutoMapper;
using VacationManager.Common.Responses;
using VacationManager.Dto.Employee;
using VacationManager.Repositories.Interfaces;
using VacationManager.Services.Interfaces;

namespace VacationManager.Services.Employee
{
    public class RetrieveAllEmployeesSvc : BaseService, IRetrieveAllEmployeesSvc
    {
        private readonly IEmployeeRepo _employeeRepo;

        public RetrieveAllEmployeesSvc(IEmployeeRepo employeeRepo, IMapper mapper) : base(mapper)
        {
            _employeeRepo = employeeRepo;
        }

        public async Task<ResponseModel<List<EmployeeDto>>> Execute()
        {
            ResponseModel<List<EmployeeDto>> result = new ResponseModel<List<EmployeeDto>>();

            var model = await _employeeRepo.RetrieveAllEmployees();

            result.Result = _mapper.Map<List<EmployeeDto>>(model);

            return result;
        }
    }
}
