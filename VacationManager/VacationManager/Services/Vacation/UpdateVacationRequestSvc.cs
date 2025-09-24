using AutoMapper;
using VacationManager.Common.Enums;
using VacationManager.Common.Responses;
using VacationManager.Dto.Vacation;
using VacationManager.Repositories.Interfaces;
using VacationManager.Services.Interfaces.Vacation;

namespace VacationManager.Services.Vacation
{
    public class UpdateVacationRequestSvc : BaseService, IUpdateVacationRequestSvc
    {
        private readonly IVacationRepo _vacationRepo;

        public UpdateVacationRequestSvc(IVacationRepo vacationRepo, IMapper mapper) : base(mapper)
        {
            _vacationRepo = vacationRepo;
        }

        public async Task<ResponseModel<bool>> Execute(VacationDto dto)
        {
            ResponseModel<bool> result = new ResponseModel<bool>();

            if(await _vacationRepo.IsVacationPeriodAlreadyBooked(dto.DateStart, dto.DateEnd, dto.Id))
            {
                result.AddError(ReasonCodeEnum.VacationPeriodAlreadyBooked);
                return result;
            }

            var model = await _vacationRepo.RetrieveVacationById(dto.Id);

            model.DateStart = dto.DateStart;
            model.DateEnd = dto.DateEnd;
            model.Details = dto.Details;
            model.Status = VacationStatusEnum.AwaitingApproval;

            result.Result = await _vacationRepo.UpdateVacation(model);

            return result;
        }
    }
}
