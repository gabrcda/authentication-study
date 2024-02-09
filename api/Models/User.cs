using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Enum;

namespace api.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public JobsEnum Job { get; set; }
        public string HashPassword { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}