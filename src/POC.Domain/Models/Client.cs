using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POC.Domain.Models
{
    public class Client
    {
        public Guid Id { get; set; }
        public  string Email { get; set; }
        public string Password { get; set; }
        public string AccessToken { get; set; }
    }
}