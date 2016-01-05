using ACMA.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using userDomain = ACMA.Domain.Entities.Access;

namespace ACMA.Models.User
{
    public class RegisterUserModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public int IdSelectListProfile { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public userDomain.User ConvertModelToDomain()
        {
            return new userDomain.User()
            {
                UserName = this.UserName,
                Password = this.Password,
                IdProfile = this.IdSelectListProfile,
                Contact = new Contact() { FullName = this.FullName, 
                                          Email = this.Email, 
                                          Phone = this.Phone}
            };
        }
    }
}