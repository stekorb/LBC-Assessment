using VacationManager.Services.Employee;
using VacationManager.Services.Interfaces.Employee;

namespace VacationManager.Services.Startup
{
    public class EmployeeServiceStartup
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IRetrieveAllEmployeesSvc, RetrieveAllEmployeesSvc>();
            services.AddTransient<ICreateEmployeeSvc, CreateEmployeeSvc>();
            services.AddTransient<IUpdateEmployeeSvc, UpdateEmployeeSvc>();
        }
    }
}
