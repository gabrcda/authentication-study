using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Services.Password
{
    public class PasswordService : IPasswordService
    {
        public string MakeProtectedPassword(string newUserPassword)
        {
            return BCrypt.Net.BCrypt.HashPassword(newUserPassword);
        }

        public bool VerifyPasswordMatch(string loginUserPassword, string loginUserHash)
        {
            return BCrypt.Net.BCrypt.Verify(loginUserPassword, loginUserHash);
        }
    }
}