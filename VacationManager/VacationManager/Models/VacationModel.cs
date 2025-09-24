using VacationManager.Common.Enums;

namespace VacationManager.Models
{
    public class VacationModel
    {
        public Guid Id { get; set; }
        public Guid EmployeeId { get; set; }
        public DateOnly DateStart { get; set; }
        public DateOnly DateEnd { get; set; }
        public string? Details { get; set; }
        public VacationStatusEnum Status { get; set; }
    }
}
