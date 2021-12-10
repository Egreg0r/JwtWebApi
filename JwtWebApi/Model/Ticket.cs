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
        public string message { get; set; }
        public LoginModel loginModel { get; set; }
        public DateTime createDate { get; set; }
    }
}
