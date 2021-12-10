using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JwtWebApi.Model;

namespace JwtWebApi.Data
{
    public class FakeDataFactory
    {
        public static IEnumerable<LoginModel> loginModels => new List<LoginModel>()
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

        public static IEnumerable<Ticket> tickets => new List<Ticket>()
        {
            new Ticket()
            {
                message = "some text from fist User",
                createDate = DateTime.Now,
                loginModel = (LoginModel)loginModels.Where(x=> x.Id == 1)
            },

            new Ticket()
            {
                message = "some text 2 from fist User",
                createDate = DateTime.Now,
                loginModel = (LoginModel)loginModels.Where(x=> x.Id == 1)
            },

            new Ticket()
            {
                message = "some text from second User",
                createDate = DateTime.Now,
                loginModel = (LoginModel)loginModels.Where(x=> x.Id == 2)
            },

        };



    }
}
