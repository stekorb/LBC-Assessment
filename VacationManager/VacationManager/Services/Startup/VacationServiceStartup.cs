using VacationManager.Services.Interfaces.Vacation;
using VacationManager.Services.Vacation;

namespace VacationManager.Services.Startup
{
    public class VacationServiceStartup
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IRetrieveAllVacationsSvc, RetrieveAllVacationsSvc>();
        }
    }
}
