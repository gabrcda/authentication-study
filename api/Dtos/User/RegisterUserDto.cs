using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using api.Enum;

namespace api.Dtos.User
{
    public class RegisterUserDto
    {
        [Required(ErrorMessage = "The field username is mandatory!")]
        public required string Username { get; set; }

        [Required(ErrorMessage = "The field job is mandatory")]
        public required JobsEnum Job { get; set; }

        [Required(ErrorMessage = "The field password is mandatory")]
        public required string Password { get; set; }

        [Compare("Password", ErrorMessage = "Password unmatched!"), Required(ErrorMessage = "The field is mandatory")]
        public required string ConfirmPassword { get; set; }
    }
}