using System.ComponentModel.DataAnnotations;
using VacationManager.Common.Enums;

namespace VacationManager.Dto.Employee
{
    public class EmployeeCreateDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public RoleEnum Role { get; set; }
        public Guid? ManagerId { get; set; }
    }
}
