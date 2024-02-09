using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.User;
using api.Models;
using api.Services.Password;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace api.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly DataContext _dbContext;
        private readonly IMapper _mapping;
        private readonly IPasswordService _passwordService;
        public AuthService(DataContext dbContext, IMapper mapping, IPasswordService passwordService)
        {
            _dbContext = dbContext;
            _mapping = mapping;
            _passwordService = passwordService;
        }

        public async Task<ServiceResponse<AddedUserDto>> Register(RegisterUserDto newUser)
        {
            var response = new ServiceResponse<AddedUserDto>();
            try
            {
                if(_dbContext.Users.Any(c => c.Username == newUser.Username))
                {
                    throw new Exception("user already exist");
                }
                var newUserModel = _mapping.Map<User>(newUser);
                newUserModel.HashPassword = _passwordService.MakeProtectedPassword(newUser.Password);
                await _dbContext.Users.AddAsync(newUserModel);
                await _dbContext.SaveChangesAsync();
                response.Data = _mapping.Map<AddedUserDto>(newUserModel);
                response.Message = "user created sucefully";

            }catch (Exception ex)
            {
                response.Data = null;
                response.Message = ex.Message;
                response.Status = false;
            }
            return response;
        }

        public async Task<ServiceResponse<LoginUserDto>> Login(LoginUserDto loginUser)
        {
            var response = new ServiceResponse<LoginUserDto>();
            try
            {
                var dbUser = await _dbContext.Users.FirstOrDefaultAsync(c => c.Username == loginUser.Username);
                if(dbUser is null)
                {
                    throw new Exception("user not found!");
                }

                if(!_passwordService.VerifyPasswordMatch(loginUser.Password, dbUser.HashPassword))
                {
                    throw new Exception("invalid credentials!");
                }

                //Implement JWT tokenization...

            }catch (Exception ex)
            {
                response.Data = null;
                response.Message = ex.Message;
                response.Status = false;   
            }
            return response;
        }
    }
}