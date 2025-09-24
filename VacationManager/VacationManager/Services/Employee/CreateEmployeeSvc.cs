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

        public async Task<ResponseModel<bool>> Execute(EmployeeCreateDto dto)
        {
            ResponseModel<bool> result = new ResponseModel<bool>();

            if(await _employeeRepo.RetrieveEmployeeByEmail(dto.Email) != null)
            {
                result.AddError(ReasonCodeEnum.EmailNotUnique);
            }

            if(dto.ManagerId.HasValue)
            {
                var manager = await _employeeRepo.RetrieveEmployeeById(dto.ManagerId.Value);
                if(manager == null)
                {
                    result.AddError(ReasonCodeEnum.ManagerNotFound);
                }
            }

            if (!result.HasErrors)
            {
                var model = _mapper.Map<EmployeeModel>(dto);
                result.Result = await _employeeRepo.CreateEmployee(model);
            }

            return result;
        }
    }
}
