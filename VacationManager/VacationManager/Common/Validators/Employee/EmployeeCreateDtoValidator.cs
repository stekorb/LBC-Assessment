using FluentValidation;
using Microsoft.EntityFrameworkCore;
using VacationManager.Common.Enums;
using VacationManager.Data;
using VacationManager.Dto.Employee;
using VacationManager.Repositories;
using VacationManager.Repositories.Interfaces;

namespace VacationManager.Common.Validators.Employee
{
    public class EmployeeCreateDtoValidator : AbstractValidator<EmployeeCreateDto>
    {
        public EmployeeCreateDtoValidator()
        {
            RuleFor(x => x.Email)
                .EmailAddress().WithMessage("Invalid email format.")
                .When(x => !string.IsNullOrEmpty(x.Email));

            RuleFor(x => x.ManagerEmail)
                .EmailAddress().WithMessage("Invalid email format.")
                .When(x => !string.IsNullOrEmpty(x.ManagerEmail));
        }
    }
}
