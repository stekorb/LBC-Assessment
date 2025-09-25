using AutoMapper;
using VacationManager.Common.Enums;
using VacationManager.Common.Responses;
using VacationManager.Dto.Vacation;
using VacationManager.Models;
using VacationManager.Repositories.Interfaces;
using VacationManager.Services.Interfaces.Authentication;
using VacationManager.Services.Interfaces.Vacation;

namespace VacationManager.Services.Vacation
{
    public class RetrieveVacationsAwaitingReviewSvc : BaseService, IRetrieveVacationsAwaitingReviewSvc
    {
        private readonly IVacationRepo _vacationRepo;
        private readonly IUserContextSvc _userContextSvc;

        public RetrieveVacationsAwaitingReviewSvc(IVacationRepo vacationRepo, IUserContextSvc userContextSvc, IMapper mapper) : base(mapper)
        {
            _vacationRepo = vacationRepo;
            _userContextSvc = userContextSvc;
        }

        public async Task<ResponseModel<List<VacationDto>>> Execute()
        {
            ResponseModel<List<VacationDto>> result = new ResponseModel<List<VacationDto>>();

            List<VacationModel> model = new List<VacationModel>();
            if(_userContextSvc.Role == RoleEnum.Administrator)
            {
                model = await _vacationRepo.RetrieveVacationsAwaitingReview();
            }
            else
            {
                model = await _vacationRepo.RetrieveVacationsAwaitingReview(_userContextSvc.UserId);
            }
            
            result.Result = _mapper.Map<List<VacationDto>>(model);

            return result;
        }
    }
}
