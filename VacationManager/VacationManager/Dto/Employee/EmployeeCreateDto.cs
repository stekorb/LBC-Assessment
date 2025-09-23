using VacationManager.Common.Enums;

namespace VacationManager.Dto.Employee
{
    public class EmployeeCreateDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public RoleEnum Role { get; set; }
        public Guid? ManagerId { get; set; }
    }
}
