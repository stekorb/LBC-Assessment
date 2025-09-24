namespace VacationManager.Services.Interfaces.Authentication
{
    public interface IAuthenticationSvc
    {
        Task<string> Authenticate(string email, string password);
    }
}
