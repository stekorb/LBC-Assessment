using AutoMapper;
using VacationManager.Common.Responses;
using VacationManager.Dto.Vacation;
using VacationManager.Repositories.Interfaces;
using VacationManager.Services.Interfaces.Vacation;

namespace VacationManager.Services.Vacation
{
    public class RetrieveVacationsAwaitingReviewSvc : BaseService, IRetrieveVacationsAwaitingReviewSvc
    {
        private readonly IVacationRepo _vacationRepo;

        public RetrieveVacationsAwaitingReviewSvc(IVacationRepo vacationRepo, IMapper mapper) : base(mapper)
        {
            _vacationRepo = vacationRepo;
        }

        public async Task<ResponseModel<List<VacationDto>>> Execute(Guid managerId)
        {
            ResponseModel<List<VacationDto>> result = new ResponseModel<List<VacationDto>>();

            var model = await _vacationRepo.RetrieveVacationsAwaitingReview(managerId);
            result.Result = _mapper.Map<List<VacationDto>>(model);

            return result;
        }
    }
}
