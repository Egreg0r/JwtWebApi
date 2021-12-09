using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JwtWebApi.Model
{
    public class LoginModel:BaseEntity
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
