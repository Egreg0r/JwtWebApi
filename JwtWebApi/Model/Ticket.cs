using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

// ---------------------------------
// Класс сообщений пользователей
// --------------------------------


namespace JwtWebApi.Model
{
    public class Ticket:BaseEntity
    {
        [Required]
        public string Message { get; set; }
        [Required]
        public string LoginModelUserName { get; set; }
        public virtual LoginModel LoginModel { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
