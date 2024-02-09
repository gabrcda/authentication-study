using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.User;
using api.Models;
using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;

namespace api.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly DataContext _dbContext;
        private readonly IMapper _mapping;
        public AuthService(DataContext dbContext, IMapper mapping)
        {
            _dbContext = dbContext;
            _mapping = mapping;
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
                newUserModel.HashPassword = MakeProtectedPassword(newUser.Password);
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

        private string MakeProtectedPassword(string newUserPassword)
        {
            return BCrypt.Net.BCrypt.HashPassword(newUserPassword);
        }
    }
}