using AutoMapper;
using VacationManager.Common.Enums;
using VacationManager.Common.Responses;
using VacationManager.Dto.Vacation;
using VacationManager.Repositories.Interfaces;
using VacationManager.Services.Interfaces.Authentication;
using VacationManager.Services.Interfaces.Vacation;

namespace VacationManager.Services.Vacation
{
    public class RetrieveVacationSvc : BaseService, IRetrieveVacationSvc
    {
        private readonly IVacationRepo _vacationRepo;
        private readonly IEmployeeRepo _employeeRepo;
        private readonly IUserContextSvc _userContextSvc;

        public RetrieveVacationSvc(IVacationRepo vacationRepo, IEmployeeRepo employeeRepo, IUserContextSvc userContextSvc, IMapper mapper) : base(mapper)
        {
            _vacationRepo = vacationRepo;
            _employeeRepo = employeeRepo;
            _userContextSvc = userContextSvc;
        }

        public async Task<ResponseModel<VacationDto>> Execute(Guid vacationId)
        {
            ResponseModel<VacationDto> result = new ResponseModel<VacationDto>();

            var model = await _vacationRepo.RetrieveVacationById(vacationId);

            if (_userContextSvc.Role == RoleEnum.Manager)
            {
                var managed = (await _employeeRepo.RetrieveManagedEmployees(_userContextSvc.UserId)).Select(emp => emp.Id).ToList();
                managed.Add(_userContextSvc.UserId);
                if (!managed.Contains(model.EmployeeId))
                {
                    result.AddError(ReasonCodeEnum.VacationNotUnderManagement);
                    return result;
                }
            }
            else if(_userContextSvc.Role == RoleEnum.Employee && model.EmployeeId != _userContextSvc.UserId)
            {
                result.AddError(ReasonCodeEnum.NotVacationOwner);
                return result;
            }
            
            result.Result = _mapper.Map<VacationDto>(model);

            return result;
        }
    }
}
