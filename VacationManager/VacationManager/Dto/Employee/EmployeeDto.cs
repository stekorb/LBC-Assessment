using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using VacationManager.Common.Enums;

namespace VacationManager.Dto.Employee
{
    public class EmployeeDto
    {
        [Required]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public RoleEnum Role { get; set; }
        public Guid? ManagerId { get; set; }
    }
}
