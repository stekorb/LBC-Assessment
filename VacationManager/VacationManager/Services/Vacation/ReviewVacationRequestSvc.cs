using AutoMapper;
using VacationManager.Common.Enums;
using VacationManager.Common.Responses;
using VacationManager.Dto.Vacation;
using VacationManager.Repositories.Interfaces;
using VacationManager.Services.Interfaces.Vacation;

namespace VacationManager.Services.Vacation
{
    public class ReviewVacationRequestSvc : BaseService, IReviewVacationRequestSvc
    {
        private readonly IVacationRepo _vacationRepo;

        public ReviewVacationRequestSvc(IVacationRepo vacationRepo, IMapper mapper) : base(mapper)
        {
            _vacationRepo = vacationRepo;
        }

        public async Task<ResponseModel<bool>> Execute(VacationReviewDto dto)
        {
            ResponseModel<bool> result = new ResponseModel<bool>();

            var model = await _vacationRepo.RetrieveVacationById(dto.Id);
            model.Status = dto.ManagerDecision;

            result.Result = await _vacationRepo.UpdateVacation(model);
            return result;
        }
    }
}
