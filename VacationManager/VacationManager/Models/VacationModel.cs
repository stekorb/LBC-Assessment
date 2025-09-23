namespace VacationManager.Models
{
    public class VacationModel
    {
        public Guid Id { get; set; }
        public EmployeeModel Employee { get; set; }
        public DateOnly DateStart { get; set; }
        public DateOnly DateEnd { get; set; }
        public string Details { get; set; }
    }
}
