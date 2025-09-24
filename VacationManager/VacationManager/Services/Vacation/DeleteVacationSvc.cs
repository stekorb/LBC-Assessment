using AutoMapper;
using VacationManager.Common.Enums;
using VacationManager.Common.Responses;
using VacationManager.Repositories.Interfaces;
using VacationManager.Services.Interfaces.Vacation;

namespace VacationManager.Services.Vacation
{
    public class DeleteVacationSvc : BaseService, IDeleteVacationSvc
    {
        private readonly IVacationRepo _vacationRepo;

        public DeleteVacationSvc(IVacationRepo vacationRepo, IMapper mapper) : base(mapper)
        {
            _vacationRepo = vacationRepo;
        }

        public async Task<ResponseModel<bool>> Execute(Guid vacationId)
        {
            ResponseModel<bool> result = new ResponseModel<bool>();

            var vacationDb = await _vacationRepo.RetrieveVacationById(vacationId);
            if (vacationDb == null)
            {
                result.AddError(ReasonCodeEnum.VacationNotFound);
                return result;
            }

            result.Result = await _vacationRepo.DeleteVacation(vacationId);
            return result;
        }
    }
}
