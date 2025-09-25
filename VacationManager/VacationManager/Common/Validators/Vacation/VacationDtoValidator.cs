using FluentValidation;
using VacationManager.Dto.Vacation;

namespace VacationManager.Common.Validators.Vacation
{
    public class VacationDtoValidator : AbstractValidator<VacationDto>
    {
        public VacationDtoValidator()
        {
            RuleFor(x => x.DateStart)
                .GreaterThanOrEqualTo(DateOnly.FromDateTime(DateTime.Today)).WithMessage("Must be on the future");

            RuleFor(x => x.DateEnd)
                .GreaterThanOrEqualTo(DateOnly.FromDateTime(DateTime.Today)).WithMessage("Must be on the future");

            RuleFor(x => x.Details)
                .MaximumLength(100).WithMessage("Exceeds 100 characters")
                .When(x => !string.IsNullOrEmpty(x.Details));
        }
    }
}
