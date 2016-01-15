using ACMA.Domain.Entities.Common;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using userDomain = ACMA.Domain.Entities.Access;

namespace ACMA.Models.User
{
    public class UpdateUserModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int IdSelectListProfile { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public bool Blocked { get; set; }
        public bool Active { get; set; }

        public static userDomain.User ConvertModelToDomain(UpdateUserModel updateUserModel)
        {
            return Mapper.Map<UpdateUserModel, userDomain.User>(updateUserModel);
        }

        public static UpdateUserModel ConvertDomainToModel(userDomain.User user)
        {
            return Mapper.Map<userDomain.User, UpdateUserModel>(user);
        }
    }
}