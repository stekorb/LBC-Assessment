using AutoMapper;
using VacationManager.Common.Enums;
using VacationManager.Common.Responses;
using VacationManager.Dto.Employee;
using VacationManager.Models;
using VacationManager.Repositories.Interfaces;
using VacationManager.Services.Interfaces;

namespace VacationManager.Services.Employee
{
    public class CreateEmployeeSvc : BaseService, ICreateEmployeeSvc
    {
        private readonly IEmployeeRepo _employeeRepo;

        public CreateEmployeeSvc(IEmployeeRepo employeeRepo, IMapper mapper) : base(mapper)
        {
            _employeeRepo = employeeRepo;
        }

        public ResponseModel<bool> Execute(EmployeeCreateDto dto)
        {
            ResponseModel<bool> result = new ResponseModel<bool>();

            if(_employeeRepo.RetrieveEmployeeByEmail(dto.Email) != null)
            {
                result.AddError(ReasonCodeEnum.EmailNotUnique);
                return result;
            }

            var model = _mapper.Map<EmployeeModel>(dto);

            result.Result = _employeeRepo.CreateEmployee(model);

            return result;
        }
    }
}
