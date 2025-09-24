using Microsoft.EntityFrameworkCore;
using VacationManager.Common.Enums;
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

        public async Task<bool> IsVacationPeriodAlreadyBooked(DateOnly start, DateOnly end)
        {
            var result = await _dbContext.Vacations.AnyAsync(x => x.Status == VacationStatusEnum.Approved && start <= x.DateEnd && x.DateStart <= end);
            return result;
        }

        public async Task<bool> RegisterNewVacation(VacationModel model)
        {
            await _dbContext.Vacations.AddAsync(model);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> UpdateVacation(VacationModel model)
        {
            var dbObj = await _dbContext.Vacations.FirstOrDefaultAsync(vac => vac.Id == model.Id);

            if (dbObj != null)
            {
                dbObj.DateStart = model.DateStart;
                dbObj.DateEnd = model.DateEnd;
                dbObj.Details = model.Details;
                dbObj.Status = model.Status;

                await _dbContext.SaveChangesAsync();

                return true;
            }

            return false;
        }
    }
}
