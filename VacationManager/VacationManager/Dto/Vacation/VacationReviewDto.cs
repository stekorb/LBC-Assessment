using VacationManager.Common.Enums;

namespace VacationManager.Dto.Vacation
{
    public class VacationReviewDto
    {
        public Guid Id { get; set; }
        public VacationStatusEnum ManagerDecision { get; set; }
    }
}
