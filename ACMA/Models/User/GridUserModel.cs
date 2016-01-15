using AutoMapper;
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

        public static GridUserModel ConvertDomainToModel(userDomain.User user)
        {
            return Mapper.Map<GridUserModel>(user);
        }
    }
}