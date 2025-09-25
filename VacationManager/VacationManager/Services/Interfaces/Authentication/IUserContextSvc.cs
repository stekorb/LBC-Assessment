using VacationManager.Common.Enums;

namespace VacationManager.Services.Interfaces.Authentication
{
    public interface IUserContextSvc
    {
        public Guid UserId { get; set; }
        public string Email { get; set; }
        public RoleEnum Role { get; set; }
    }
}
