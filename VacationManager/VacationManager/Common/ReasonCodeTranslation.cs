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
                { ReasonCodeEnum.EmailNotUnique, "Email must be unique." },
                { ReasonCodeEnum.ManagerNotFound, "ManagerEmail must already be registered to a manager." },
                { ReasonCodeEnum.EmployeeNotFound, "Employee not found." },
            };
        }

        public string TranslateErrorCode(ReasonCodeEnum reasonCodeEnum)
        {
            return Dictionary[reasonCodeEnum];
        }
    }
}
