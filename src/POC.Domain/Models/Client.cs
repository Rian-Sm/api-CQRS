using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POC.Domain.Models
{
    public class Client
    {
        public Guid Id { get; set; }
        public  string email { get; set; }
        public string password { get; set; }
        public string acessToken { get; set; }
  
    }
}