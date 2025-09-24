using Microsoft.AspNetCore.Identity;

namespace VacationManager.Common.Helpers
{
    public class EncryptingHelper
    {
        //private readonly PasswordHasher<object> _hasher = new PasswordHasher<object>();

        public static string HashPassword(string pwd)
        {
            PasswordHasher<object> hasher = new PasswordHasher<object>();
            return hasher.HashPassword(null, pwd);
        }

        public static bool VerifyPassword(string hashed, string pwd)
        {
            PasswordHasher<object> hasher = new PasswordHasher<object>();
            var result = hasher.VerifyHashedPassword(null, hashed, pwd);
            return result == PasswordVerificationResult.Success;
        }
    }
}
