using VacationManager.Common.Enums;

namespace VacationManager.Common
{
    public class ReasonCodeTranslation
    {
        public Dictionary<ReasonCodeEnum, string> Dictionary;

        public ReasonCodeTranslation()
        {
            Dictionary = new Dictionary<ReasonCodeEnum, string>
            {
                { ReasonCodeEnum.UserNotFound, "User does not exists." },

                //Employee
                { ReasonCodeEnum.EmailNotUnique, "Email must be unique." },
                { ReasonCodeEnum.ManagerNotFound, "ManagerId must already be registered to a manager." },
                { ReasonCodeEnum.EmployeeNotFound, "Employee was not found." },

                //Vacation
                { ReasonCodeEnum.VacationPeriodAlreadyBooked, "Vacation period is already booked for another." },
                { ReasonCodeEnum.VacationNotUnderManagement, "Vacation is not from an employee from another manager." },
                { ReasonCodeEnum.NotVacationOwner, "Vacation is not owned by the employee." },
                { ReasonCodeEnum.NotAllowedToSeeEmployeeVacations, "User does not have permission to retrieve this user's vacations." },
                { ReasonCodeEnum.DoesNotHaveReviewPermission, "User does not have permission to review this vacation." },
                { ReasonCodeEnum.DoesNotHaveEditPermission, "User does not have permission to edit this vacation." },
                { ReasonCodeEnum.DoesNotHaveDeletePermission, "User does not have permission to delete this vacation." },
            };
        }

        public string TranslateErrorCode(ReasonCodeEnum reasonCodeEnum)
        {
            return Dictionary[reasonCodeEnum];
        }
    }
}
