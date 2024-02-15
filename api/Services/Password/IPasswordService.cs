using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Services.Password
{
    public interface IPasswordService
    {
        public string MakeProtectedPassword(string newUserPassword);
        public bool VerifyPasswordMatch(string loginUserPassword, string loginUserHash);
        public string TokenCreation(User loginUser);
    }
}