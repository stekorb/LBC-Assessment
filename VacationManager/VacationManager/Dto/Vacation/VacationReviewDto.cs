using System.ComponentModel.DataAnnotations;
using VacationManager.Common.Enums;

namespace VacationManager.Dto.Vacation
{
    public class VacationReviewDto
    {
        [Required]
        public Guid VacationId { get; set; }

        [Required]
        public VacationStatusEnum ManagerDecision { get; set; }
    }
}
