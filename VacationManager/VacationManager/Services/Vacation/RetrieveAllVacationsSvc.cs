using AutoMapper;
using VacationManager.Common.Responses;
using VacationManager.Dto.Vacation;
using VacationManager.Repositories.Interfaces;
using VacationManager.Services.Interfaces.Vacation;

namespace VacationManager.Services.Vacation
{
    public class RetrieveAllVacationsSvc : BaseService, IRetrieveAllVacationsSvc
    {
        private readonly IVacationRepo _vacationRepo;

        public RetrieveAllVacationsSvc(IVacationRepo vacationRepo, IMapper mapper) : base(mapper)
        {
            _vacationRepo = vacationRepo;
        }

        public async Task<ResponseModel<List<VacationDto>>> Execute()
        {
            ResponseModel<List<VacationDto>> result = new ResponseModel<List<VacationDto>>();
            var model = await _vacationRepo.RetrieveAllVacations();

            result.Result = _mapper.Map<List<VacationDto>>(model);
            return result;
        }
    }
}
