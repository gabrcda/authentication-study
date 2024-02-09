using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.User;
using api.Models;
using AutoMapper;

namespace api
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<RegisterUserDto, User>();
            CreateMap<User, AddedUserDto>();
        }
    }
}