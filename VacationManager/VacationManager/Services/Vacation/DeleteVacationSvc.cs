using AutoMapper;
using VacationManager.Common.Enums;
using VacationManager.Common.Responses;
using VacationManager.Repositories.Interfaces;
using VacationManager.Services.Interfaces.Authentication;
using VacationManager.Services.Interfaces.Vacation;

namespace VacationManager.Services.Vacation
{
    public class DeleteVacationSvc : BaseService, IDeleteVacationSvc
    {
        private readonly IVacationRepo _vacationRepo;
        private readonly IUserContextSvc _userContextSvc;

        public DeleteVacationSvc(IVacationRepo vacationRepo, IUserContextSvc userContextSvc, IMapper mapper) : base(mapper)
        {
            _vacationRepo = vacationRepo;
            _userContextSvc = userContextSvc;
        }

        public async Task<ResponseModel<bool>> Execute(Guid vacationId)
        {
            ResponseModel<bool> result = new ResponseModel<bool>();

            if (!await _vacationRepo.HasVacationAccess(vacationId, _userContextSvc.UserId))
            {
                result.AddError(ReasonCodeEnum.DoesNotHaveEditPermission);
                return result;
            }

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
