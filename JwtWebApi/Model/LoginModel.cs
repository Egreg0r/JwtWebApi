using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

// ---------------------------------
// Класс с данными пользователей
// --------------------------------

namespace JwtWebApi.Model
{
    [Index("UserName", IsUnique = true)]
    public class LoginModel:BaseEntity
    {
        [Required]
        [MinLength(3, ErrorMessage="Имя не менее трех символов")]
        public string UserName { get; set; }
        
        [Required]
        [MinLength(6, ErrorMessage ="Пароль должен быть не менее 6 символов")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
