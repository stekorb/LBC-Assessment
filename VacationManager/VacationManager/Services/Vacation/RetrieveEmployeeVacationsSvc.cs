using AutoMapper;
using VacationManager.Common.Enums;
using VacationManager.Common.Responses;
using VacationManager.Dto.Vacation;
using VacationManager.Repositories.Interfaces;
using VacationManager.Services.Interfaces.Vacation;

namespace VacationManager.Services.Vacation
{
    public class RetrieveEmployeeVacationsSvc : BaseService, IRetrieveEmployeeVacationsSvc
    {
        private readonly IVacationRepo _vacationRepo;
        private readonly IEmployeeRepo _employeeRepo;

        public RetrieveEmployeeVacationsSvc(IVacationRepo vacationRepo, IEmployeeRepo employeeRepo, IMapper mapper) : base(mapper)
        {
            _vacationRepo = vacationRepo;
            _employeeRepo = employeeRepo;
        }

        public async Task<ResponseModel<List<VacationDto>>> Execute(Guid employeeId)
        {
            ResponseModel<List<VacationDto>> result = new ResponseModel<List<VacationDto>>();

            if(await _employeeRepo.RetrieveEmployeeById(employeeId) == null)
            {
                result.AddError(ReasonCodeEnum.EmployeeNotFound);
                return result;
            }

            var model = await _vacationRepo.RetrieveEmployeeVacations(employeeId);

            result.Result = _mapper.Map<List<VacationDto>>(model);
            return result;
        }
    }
}
