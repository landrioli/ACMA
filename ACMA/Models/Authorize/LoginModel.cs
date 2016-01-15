using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using userDomain = ACMA.Domain.Entities.Access;

namespace ACMA.Models.Authorize
{
    public class LoginModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string PreviousUrl { get; set; }

        public static userDomain.User ConvertModelToDomain(LoginModel loginModel)
        {
            return Mapper.Map<LoginModel, userDomain.User>(loginModel);
        }
    }
}