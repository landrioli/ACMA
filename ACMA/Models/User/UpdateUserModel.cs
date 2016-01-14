using ACMA.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using userDomain = ACMA.Domain.Entities.Access;

namespace ACMA.Models.User
{
    public class UpdateUserModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public int IdSelectListProfile { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public bool Blocked { get; set; }
        public bool Active { get; set; }

        public userDomain.User ConvertModelToDomain()
        {
            return new userDomain.User()
            {
                UserName = this.UserName,
                Password = this.Password,
                IdProfile = this.IdSelectListProfile,
                Contact = new Contact()
                {
                    FullName = this.FullName,
                    Email = this.Email,
                    Phone = this.Phone
                },
                Blocked = this.Blocked,
                Active = this.Active
            };
        }

        public void ConvertDomainToModel(userDomain.User user)
        {
            this.UserName = user.UserName;
            this.Password = user.Password;
            this.IdSelectListProfile = user.IdProfile;
            this.FullName = user.Contact.FullName;
            this.Email = user.Contact.Email;
            this.Phone = user.Contact.Phone;
            this.Blocked = user.Blocked;
            this.Active = user.Active;
        }
    }
}