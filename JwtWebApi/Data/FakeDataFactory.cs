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
                Id = 1,
                UserName = "FirstUser",
                Password = "PasswordFistUser",
            },

            new LoginModel()
            {
                Id = 2,
                UserName = "SecondUser",
                Password = "PasswordSecond",
            }
        };

        public static IEnumerable<Ticket> defTickets => new List<Ticket>()
        {
            new Ticket()
            {
                Id = 1,
                message = "some text from fist User",
                createDate = DateTime.Now,
                loginModelId = defLoginModels.First(x => x.Id == 1).Id
            },

            new Ticket()
            {
                Id = 2,
                message = "some text 2 from fist User",
                createDate = DateTime.Now,
                loginModelId = defLoginModels.First(x => x.Id == 1).Id
            },

            new Ticket()
            {
                Id = 3,
                message = "some text from second User",
                createDate = DateTime.Now,
                loginModelId = defLoginModels.First(x => x.Id == 2).Id

            },

        };

    }
}
