using AutoMapper;
using VacationManager.Common.Enums;
using VacationManager.Common.Responses;
using VacationManager.Dto.Vacation;
using VacationManager.Models;
using VacationManager.Repositories.Interfaces;
using VacationManager.Services.Interfaces.Vacation;

namespace VacationManager.Services.Vacation
{
    public class RegisterNewVacationSvc : BaseService, IRegisterNewVacationSvc
    {
        private readonly IVacationRepo _vacationRepo;

        public RegisterNewVacationSvc(IVacationRepo vacationRepo, IMapper mapper) : base(mapper)
        {
            _vacationRepo = vacationRepo;
        }

        public async Task<ResponseModel<bool>> Execute(VacationCreateDto dto)
        {
            ResponseModel<bool> result = new ResponseModel<bool>();

            if (await _vacationRepo.IsVacationPeriodAlreadyBooked(dto.DateStart, dto.DateEnd))
            {
                result.AddError(ReasonCodeEnum.VacationPeriodAlreadyBooked);
                return result;
            }

            var model = _mapper.Map<VacationModel>(dto);
            model.Status = VacationStatusEnum.WaitingApproval;
            result.Result = await _vacationRepo.RegisterNewVacation(model);
            return result;
        }
    }
}
