using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.User
{
    public class LoginUserDto
    {
        [Required(ErrorMessage = "The field username is mandatory!")]
        public required string Username { get; set; }

        [Required(ErrorMessage = "The field password is mandatory")]
        public required string Password { get; set; }
    }
}