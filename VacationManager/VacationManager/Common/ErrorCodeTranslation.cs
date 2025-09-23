using VacationManager.Common.Enums;

namespace VacationManager.Common
{
    public class ErrorCodeTranslation
    {
        public Dictionary<ReasonCodeEnum, string> Dictionary;

        public ErrorCodeTranslation()
        {
            Dictionary = new Dictionary<ReasonCodeEnum, string>
            {
                { ReasonCodeEnum.EmailNotUnique, "Email already registered." }
            };
        }

        public string TranslateErrorCode(ReasonCodeEnum reasonCodeEnum)
        {
            return Dictionary[reasonCodeEnum];
        }
    }
}
