using VacationManager.Services.Interfaces.Vacation;
using VacationManager.Services.Vacation;

namespace VacationManager.Services.Startup
{
    public class VacationServiceStartup
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IRetrieveAllVacationsSvc, RetrieveAllVacationsSvc>();
            services.AddScoped<IRetrieveEmployeeVacationsSvc, RetrieveEmployeeVacationsSvc>();
            services.AddScoped<IRetrieveVacationSvc, RetrieveVacationSvc>();
            services.AddScoped<IRegisterNewVacationSvc, RegisterNewVacationSvc>();
            services.AddScoped<IReviewVacationRequestSvc, ReviewVacationRequestSvc>();
            services.AddScoped<IUpdateVacationRequestSvc, UpdateVacationRequestSvc>();
            services.AddScoped<IDeleteVacationSvc, DeleteVacationSvc>();
            services.AddScoped<IRetrieveVacationsAwaitingReviewSvc, RetrieveVacationsAwaitingReviewSvc>();
        }
    }
}
