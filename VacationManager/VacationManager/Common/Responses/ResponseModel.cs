using VacationManager.Common.Enums;

namespace VacationManager.Common.Responses
{
    public class ResponseModel<T>
    {
        public T? Result { get; set; }
        public List<ErrorResponseModel> Errors { get; set; }
        public bool HasErrors => Errors.Any();

        public ResponseModel()
        {
            Errors = new();
        }

        public ResponseModel(T result)
        {
            Result = result;
            Errors = new();
        }

        public void AddError(ReasonCodeEnum reasonCode)
        {
            Errors.Add(new ErrorResponseModel { ReasonCode = reasonCode });
        }
    }
}
