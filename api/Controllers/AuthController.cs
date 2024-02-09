using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.User;
using api.Models;
using api.Services.Auth;
using Microsoft.AspNetCore.Mvc;
using SQLitePCL;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("api/Register")]
        public async Task<ActionResult<ServiceResponse<AddedUserDto>>> Register(RegisterUserDto newUser)
        {
            var response = await _authService.Register(newUser);
            if(!response.Status) { return BadRequest(response);}
            return Ok(response);
        }
    }
}