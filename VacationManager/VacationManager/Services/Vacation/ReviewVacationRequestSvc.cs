using AutoMapper;
using VacationManager.Common.Enums;
using VacationManager.Common.Responses;
using VacationManager.Dto.Vacation;
using VacationManager.Repositories.Interfaces;
using VacationManager.Services.Interfaces.Authentication;
using VacationManager.Services.Interfaces.Vacation;

namespace VacationManager.Services.Vacation
{
    public class ReviewVacationRequestSvc : BaseService, IReviewVacationRequestSvc
    {
        private readonly IVacationRepo _vacationRepo;
        private readonly IUserContextSvc _userContextSvc;

        public ReviewVacationRequestSvc(IVacationRepo vacationRepo, IUserContextSvc userContextSvc, IMapper mapper) : base(mapper)
        {
            _vacationRepo = vacationRepo;
            _userContextSvc = userContextSvc;
        }

        public async Task<ResponseModel<bool>> Execute(VacationReviewDto dto)
        {
            ResponseModel<bool> result = new ResponseModel<bool>();

            if(!await _vacationRepo.HasVacationAccess(dto.VacationId, _userContextSvc.UserId))
            {
                result.AddError(ReasonCodeEnum.DoesNotHaveReviewPermission);
                return result;
            }

            var model = await _vacationRepo.RetrieveVacationById(dto.VacationId);
            model.Status = dto.ManagerDecision;

            result.Result = await _vacationRepo.UpdateVacation(model);
            return result;
        }
    }
}
