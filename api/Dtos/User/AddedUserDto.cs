using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.User
{
    public class AddedUserDto
    {
        public string Username { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
    }
}