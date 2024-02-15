using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using api.Models;
using Microsoft.IdentityModel.Tokens;

namespace api.Services.Password
{
    public class PasswordService : IPasswordService
    {
        private readonly IConfiguration _config;

        public PasswordService(IConfiguration config)
        {
            _config = config;
        }

        public string MakeProtectedPassword(string newUserPassword)
        {
            return BCrypt.Net.BCrypt.HashPassword(newUserPassword);
        }

        public bool VerifyPasswordMatch(string loginUserPassword, string loginUserHash)
        {
            return BCrypt.Net.BCrypt.Verify(loginUserPassword, loginUserHash);
        }

        public string TokenCreation(User loginUser)
        {
            List<Claim> claims = new List<Claim>()
            {
                new Claim("Username", loginUser.Username),
                new Claim("Job", loginUser.Job.ToString())
            };

            var keyToken = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Token").Value));
            
            var credentialToken = new SigningCredentials(keyToken, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: credentialToken
            );

            var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);
            return jwtToken;
        }
    }
}