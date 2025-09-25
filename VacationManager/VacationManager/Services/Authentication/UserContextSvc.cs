using System.Security.Claims;
using VacationManager.Common.Enums;
using VacationManager.Services.Interfaces.Authentication;

namespace VacationManager.Services.Authentication
{
    public class UserContextSvc : IUserContextSvc
    {
        public Guid UserId { get; set; }
        public string Email { get; set; }
        public RoleEnum Role { get; set; }

        public UserContextSvc(IHttpContextAccessor context)
        {
            UserId = GetGuidFromString(context.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
            Email = context.HttpContext.User.FindFirstValue(ClaimTypes.Name) ?? "";
            Role = GetRoleEnumFromString(context.HttpContext.User.FindFirstValue(ClaimTypes.Role));
        }

        private Guid GetGuidFromString(string guid)
        {
            if (Guid.TryParse(guid, out Guid result))
            {
                return result;
            }

            return Guid.Empty;
        }

        private RoleEnum GetRoleEnumFromString(string role)
        {
            return (RoleEnum)Enum.Parse(typeof(RoleEnum), role, true);
        }
    }
}
