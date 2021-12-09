using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JwtWebApi.Model
{
    public class Ticket:BaseEntity
    {
        public string message { get; set; }
        public LoginModel loginModel { get; set; }
    }
}
