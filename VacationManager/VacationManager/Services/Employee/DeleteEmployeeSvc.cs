using AutoMapper;
using VacationManager.Common.Enums;
using VacationManager.Common.Responses;
using VacationManager.Repositories.Interfaces;
using VacationManager.Services.Interfaces.Employee;

namespace VacationManager.Services.Employee
{
    public class DeleteEmployeeSvc : BaseService, IDeleteEmployeeSvc
    {
        private readonly IEmployeeRepo _employeeRepo;

        public DeleteEmployeeSvc(IEmployeeRepo employeeRepo, IMapper mapper) : base(mapper)
        {
            _employeeRepo = employeeRepo;
        }

        public async Task<ResponseModel<bool>> Execute(Guid employeeId)
        {
            ResponseModel<bool> result = new ResponseModel<bool>();

            var employeeDb = await _employeeRepo.RetrieveEmployeeById(employeeId);
            if (employeeDb == null)
            {
                result.AddError(ReasonCodeEnum.EmployeeNotFound);
                return result;
            }

            result.Result = await _employeeRepo.DeleteEmployee(employeeId);
            return result;
        }
    }
}
