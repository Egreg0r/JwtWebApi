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
        public string message { get; set; }
        [Required]
        public int loginModelId { get; set; }
        public virtual LoginModel LoginModel { get; set; }
        public DateTime createDate { get; set; }
    }
}
