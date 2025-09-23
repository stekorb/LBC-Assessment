using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using VacationManager.Common.Enums;

namespace VacationManager.Common.Responses
{
    public class ErrorResponseModel
    {
        public ReasonCodeEnum ReasonCode { get; set; }
        public string Message => TranslateErrorCode(ReasonCode);


        private readonly ErrorCodeTranslation _translation;
        public ErrorResponseModel()
        {
            _translation = new ErrorCodeTranslation();
        }

        protected string TranslateErrorCode(ReasonCodeEnum reasonCode)
        {
            return _translation.TranslateErrorCode(reasonCode);
        }
    }
}
