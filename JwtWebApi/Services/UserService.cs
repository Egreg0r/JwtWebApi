using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JwtWebApi.Model;

namespace JwtWebApi.Services
{
    public class UserService
    {
        public bool IsValidUserInformation(LoginModel model)
        {
            if (model.UserName.Equals("Jay") && model.Password.Equals("123456")) return true;
            else return false;
        }

    }
}
