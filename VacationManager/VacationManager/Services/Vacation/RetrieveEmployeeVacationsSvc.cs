using AutoMapper;
using VacationManager.Common.Enums;
using VacationManager.Common.Responses;
using VacationManager.Dto.Vacation;
using VacationManager.Repositories.Interfaces;
using VacationManager.Services.Interfaces.Authentication;
using VacationManager.Services.Interfaces.Vacation;

namespace VacationManager.Services.Vacation
{
    public class RetrieveEmployeeVacationsSvc : BaseService, IRetrieveEmployeeVacationsSvc
    {
        private readonly IVacationRepo _vacationRepo;
        private readonly IEmployeeRepo _employeeRepo;
        private readonly IUserContextSvc _userContextSvc;

        public RetrieveEmployeeVacationsSvc(IVacationRepo vacationRepo, IEmployeeRepo employeeRepo, IUserContextSvc userContextSvc, IMapper mapper) : base(mapper)
        {
            _vacationRepo = vacationRepo;
            _employeeRepo = employeeRepo;
            _userContextSvc = userContextSvc;
        }

        public async Task<ResponseModel<List<VacationDto>>> Execute(Guid employeeId)
        {
            ResponseModel<List<VacationDto>> result = new ResponseModel<List<VacationDto>>();

            if(_userContextSvc.Role == RoleEnum.Employee && _userContextSvc.UserId != employeeId)
            {
                result.AddError(ReasonCodeEnum.NotAllowedToSeeEmployeeVacations);
                return result;
            }
            
            var employee = await _employeeRepo.RetrieveEmployeeById(employeeId);
            if(_userContextSvc.Role == RoleEnum.Manager && _userContextSvc.UserId == employee.ManagerId)
            {
                result.AddError(ReasonCodeEnum.NotAllowedToSeeEmployeeVacations);
                return result;
            }

            var model = await _vacationRepo.RetrieveEmployeeVacations(employeeId);

            result.Result = _mapper.Map<List<VacationDto>>(model);
            return result;
        }
    }
}
