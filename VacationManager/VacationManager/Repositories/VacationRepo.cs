using Microsoft.EntityFrameworkCore;
using VacationManager.Data;
using VacationManager.Models;
using VacationManager.Repositories.Interfaces;

namespace VacationManager.Repositories
{
    public class VacationRepo : IVacationRepo
    {
        private AppDbContext _dbContext;

        public VacationRepo(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<VacationModel>> RetrieveAllVacations()
        {
            var result = await _dbContext.Vacations.ToListAsync();
            return result;
        }

        public async Task<List<VacationModel>> RetrieveEmployeeVacations(Guid employeeId)
        {
            var result = await _dbContext.Vacations.Where(x => x.EmployeeId == employeeId).ToListAsync();
            return result;
        }

        public async Task<VacationModel> RetrieveVacation(Guid vacationId)
        {
            var result = await _dbContext.Vacations.FirstOrDefaultAsync(x => x.Id == vacationId);
            return result;
        }
    }
}
