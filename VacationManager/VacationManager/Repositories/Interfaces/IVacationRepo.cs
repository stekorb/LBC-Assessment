using VacationManager.Models;

namespace VacationManager.Repositories.Interfaces
{
    public interface IVacationRepo
    {
        Task<List<VacationModel>> RetrieveAllVacations();
        Task<List<VacationModel>> RetrieveEmployeeVacations(Guid employeeId);
        Task<VacationModel> RetrieveVacationById(Guid vacationId);
        Task<bool> IsVacationPeriodAlreadyBooked(DateOnly start, DateOnly end, Guid? excludeVacationId = null);
        Task<bool> RegisterNewVacation(VacationModel model);
        Task<bool> UpdateVacation(VacationModel model);
        Task<bool> DeleteVacation(Guid vacationId);
    }
}
