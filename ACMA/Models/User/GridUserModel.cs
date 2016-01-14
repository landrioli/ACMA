using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using userDomain = ACMA.Domain.Entities.Access;

namespace ACMA.Models.User
{
    public class GridUserModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public bool Blocked { get; set; }
        public bool Active { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int IdProfile { get; set; }

        public void ConvertDomainToModel(userDomain.User user)
        {
            this.Id = user.Id;
            this.FullName = user.Contact.FullName;
            this.Blocked = user.Blocked;
            this.Active = user.Active;
            this.Phone = user.Contact.Phone;
            this.Email = user.Contact.Email;
            this.IdProfile = user.IdProfile;
        }
    }
}