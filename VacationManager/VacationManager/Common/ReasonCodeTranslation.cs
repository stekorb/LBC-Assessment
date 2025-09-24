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
                //Employee
                { ReasonCodeEnum.EmailNotUnique, "Email must be unique." },
                { ReasonCodeEnum.ManagerNotFound, "ManagerId must already be registered to a manager." },
                { ReasonCodeEnum.EmployeeNotFound, "Employee was not found." },

                //Vacation
                { ReasonCodeEnum.VacationPeriodAlreadyBooked, "Vacation period is already booked for another." },
            };
        }

        public string TranslateErrorCode(ReasonCodeEnum reasonCodeEnum)
        {
            return Dictionary[reasonCodeEnum];
        }
    }
}
