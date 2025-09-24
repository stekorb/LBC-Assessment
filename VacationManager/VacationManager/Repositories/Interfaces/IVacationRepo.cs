using VacationManager.Models;

namespace VacationManager.Repositories.Interfaces
{
    public interface IVacationRepo
    {
        Task<List<VacationModel>> RetrieveAllVacations();
        Task<List<VacationModel>> RetrieveEmployeeVacations(Guid employeeId);
        Task<VacationModel> RetrieveVacation(Guid vacationId);
        Task<bool> IsVacationPeriodAlreadyBooked(DateOnly start, DateOnly end);
        Task<bool> RegisterNewVacation(VacationModel model);
        Task<bool> UpdateVacation(VacationModel model);
    }
}
