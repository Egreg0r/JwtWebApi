using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JwtWebApi.Model;

namespace JwtWebApi.Data
{
    public class FakeDataFactory
    {
        public static IEnumerable<LoginModel> defLoginModels => new List<LoginModel>()
        {
            new LoginModel()
            {
                UserName = "FirstUser",
                Password = "PasswordFistUser",
            },

            new LoginModel()
            {
                UserName = "SecondUser",
                Password = "PasswordSecond",
            }
        };

        public static IEnumerable<Ticket> defTickets => new List<Ticket>()
        {
            new Ticket()
            {
                Id =1,
                Message = "some text №1 from fist User",
                CreateDate = DateTime.Now,
                LoginModelUserName = defLoginModels.First(x => x.UserName == "FirstUser").UserName
            },

            new Ticket()
            {
                Id = 2,
                Message = "some text №2 from fist User",
                CreateDate = DateTime.Now,
                LoginModelUserName = defLoginModels.First(x => x.UserName == "FirstUser").UserName
            },
            new Ticket()
            {
                Id = 3,
                Message = "some text №3 from fist User",
                CreateDate = DateTime.Now,
                LoginModelUserName = defLoginModels.First(x => x.UserName == "FirstUser").UserName
            },

            new Ticket()
            {
                Id = 4,
                Message = "some text №4 from fist User",
                CreateDate = DateTime.Now,
                LoginModelUserName = defLoginModels.First(x => x.UserName == "FirstUser").UserName
            },

            new Ticket()
            {
                Id = 5,
                Message = "some text №1 from second User",
                CreateDate = DateTime.Now,
                LoginModelUserName = defLoginModels.First(x => x.UserName == "SecondUser").UserName
            },

        };

    }
}
