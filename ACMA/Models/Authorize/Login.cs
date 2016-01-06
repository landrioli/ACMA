using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using userDomain = ACMA.Domain.Entities.Access;

namespace ACMA.Models.Authorize
{
    public class Login
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string PreviousUrl { get; set; }

        public userDomain.User ConvertModelToDomain()
        {
            return new userDomain.User()
            {
                UserName = this.UserName,
                Password = this.Password
            };
        }
    }
}