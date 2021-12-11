using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JwtWebApi.Model;

namespace JwtWebApi.Services
{

    public interface IUserService
    {
        bool IsValidUserInformation(LoginModel model, BaseContext context);
    }
}
