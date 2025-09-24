using AutoMapper;
using VacationManager.Common.Responses;
using VacationManager.Dto.Vacation;
using VacationManager.Repositories.Interfaces;
using VacationManager.Services.Interfaces.Vacation;

namespace VacationManager.Services.Vacation
{
    public class RetrieveVacationSvc : BaseService, IRetrieveVacationSvc
    {
        private readonly IVacationRepo _vacationRepo;

        public RetrieveVacationSvc(IVacationRepo vacationRepo, IMapper mapper) : base(mapper)
        {
            _vacationRepo = vacationRepo;
        }

        public async Task<ResponseModel<VacationDto>> Execute(Guid vacationId)
        {
            ResponseModel<VacationDto> result = new ResponseModel<VacationDto>();

            var model = await _vacationRepo.RetrieveVacation(vacationId);
            result.Result = _mapper.Map<VacationDto>(model);

            return result;
        }
    }
}
