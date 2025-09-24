using AutoMapper;
using VacationManager.Common.Enums;
using VacationManager.Common.Responses;
using VacationManager.Dto.Employee;
using VacationManager.Models;
using VacationManager.Repositories.Interfaces;
using VacationManager.Services.Interfaces.Employee;

namespace VacationManager.Services.Employee
{
    public class UpdateEmployeeSvc : BaseService, IUpdateEmployeeSvc
    {
        private readonly IEmployeeRepo _employeeRepo;

        public UpdateEmployeeSvc(IEmployeeRepo employeeRepo, IMapper mapper) : base(mapper)
        {
            _employeeRepo = employeeRepo;
        }

        public async Task<ResponseModel<bool>> Execute(EmployeeDto dto)
        {
            ResponseModel<bool> result = new ResponseModel<bool>();

            var employeeDb = await _employeeRepo.RetrieveEmployeeById(dto.Id);
            if (employeeDb == null)
            {
                result.AddError(ReasonCodeEnum.EmployeeNotFound);
                return result;
            }

            var emailValidation = await _employeeRepo.RetrieveEmployeeByEmail(dto.Email);
            if (emailValidation != null && emailValidation.Id != dto.Id)
            {
                result.AddError(ReasonCodeEnum.EmailNotUnique);
            }

            if (dto.ManagerId.HasValue)
            {
                var manager = await _employeeRepo.RetrieveEmployeeById(dto.ManagerId.Value);
                if (manager == null)
                {
                    result.AddError(ReasonCodeEnum.ManagerNotFound);
                }
            }

            if (!result.HasErrors)
            {
                var model = _mapper.Map<EmployeeModel>(dto);
                result.Result = await _employeeRepo.UpdateEmployee(model);
            }

            return result;
        }
    }
}
