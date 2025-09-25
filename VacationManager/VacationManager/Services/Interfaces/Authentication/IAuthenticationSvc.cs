using VacationManager.Common.Responses;

namespace VacationManager.Services.Interfaces.Authentication
{
    public interface IAuthenticationSvc
    {
        Task<ResponseModel<string>> Authenticate(string email, string password);
    }
}
