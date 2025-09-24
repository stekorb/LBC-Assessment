namespace VacationManager.Dto.Vacation
{
    public class VacationCreateDto
    {
        public Guid EmployeeId { get; set; }
        public DateOnly DateStart { get; set; }
        public DateOnly DateEnd { get; set; }
        public string? Details { get; set; }
    }
}
