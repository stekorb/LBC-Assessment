using FluentValidation;
using VacationManager.Dto.Employee;

namespace VacationManager.Common.Validators.Employee
{
    public class EmployeeDtoValidator : AbstractValidator<EmployeeDto>
    {
        public EmployeeDtoValidator()
        {
            RuleFor(x => x.Email)
                .EmailAddress().WithMessage("Invalid email format.")
                .When(x => !string.IsNullOrEmpty(x.Email));
        }
    }
}
