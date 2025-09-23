using VacationManager.Common.Enums;

namespace VacationManager.Models
{
    public class EmployeeModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public RoleEnum Role { get; set; }
        public Guid? ManagerId { get; set; }
    }
}
