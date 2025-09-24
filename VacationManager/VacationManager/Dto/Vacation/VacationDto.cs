namespace VacationManager.Dto.Vacation
{
    public class VacationDto
    {
        public Guid Id { get; set; }
        public Guid EmployeeId { get; set; }
        public DateOnly DateStart { get; set; }
        public DateOnly DateEnd { get; set; }
        public string? Details { get; set; }
    }
}
