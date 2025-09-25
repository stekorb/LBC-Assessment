using AutoMapper;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using VacationManager.Common.Helpers;
using VacationManager.Common.Settings;
using VacationManager.Repositories.Interfaces;
using VacationManager.Services.Interfaces.Authentication;

namespace VacationManager.Services.Authentication
{
    public class AuthenticationSvc : BaseService, IAuthenticationSvc
    {
        private readonly IEmployeeRepo _employeeRepo;
        private readonly JwtSettings _jwtSettings;
        public AuthenticationSvc(IEmployeeRepo employeeRepo, IOptions<JwtSettings> jwtSettings, IMapper mapper) : base(mapper)
        {
            _employeeRepo = employeeRepo;
            _jwtSettings = jwtSettings.Value;
        }

        public async Task<string> Authenticate(string email, string password)
        {
            var user = await _employeeRepo.RetrieveEmployeeByEmail(email);
            if(EncryptingHelper.VerifyPassword(user.Password, password))
            {
                if(_jwtSettings.SecretKey != null)
                {
                    var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SecretKey));
                    var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                    var claims = new[]
                    {
                        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                        new Claim(ClaimTypes.Name, email),
                        new Claim(ClaimTypes.Role, user.Role.ToString()),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                    };

                    var token = new JwtSecurityToken(
                        issuer: _jwtSettings.Issuer,
                        audience: _jwtSettings.Audience,
                        claims: claims,
                        expires: DateTime.Now.AddHours(1),
                        signingCredentials: credentials);

                    return new JwtSecurityTokenHandler().WriteToken(token);
                }
            }

            return null;
        }
    }
}
