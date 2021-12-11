using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JwtWebApi.Model;

namespace JwtWebApi.Services
{
    public class UserService : IUserService
    {
        public bool IsValidUserInformation(LoginModel model, BaseContext context)
        {
            if (context.loginModels.FirstOrDefault(x => x.UserName == model.UserName && x.Password == model.Password)!=null) return true;
            //if (model.UserName.Equals("FirstUser") && model.Password.Equals("PasswordFistUser")) return true;
            else return false;
        }

    }
}
