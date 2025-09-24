using VacationManager.Services.Employee;
using VacationManager.Services.Interfaces.Employee;

namespace VacationManager.Services.Startup
{
    public class EmployeeServiceStartup
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IRetrieveAllEmployeesSvc, RetrieveAllEmployeesSvc>();
            services.AddScoped<ICreateEmployeeSvc, CreateEmployeeSvc>();
            services.AddScoped<IUpdateEmployeeSvc, UpdateEmployeeSvc>();
            services.AddScoped<IDeleteEmployeeSvc, DeleteEmployeeSvc>();
            services.AddScoped<IRetrieveManagedEmployeesSvc, RetrieveManagedEmployeesSvc>();
        }
    }
}
