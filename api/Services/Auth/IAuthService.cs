using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.User;
using api.Models;

namespace api.Services.Auth
{
    public interface IAuthService
    {
        public Task<ServiceResponse<AddedUserDto>> Register(RegisterUserDto newUser);
        public Task<ServiceResponse<LoginUserDto>> Login(LoginUserDto loginUser);
    }
}