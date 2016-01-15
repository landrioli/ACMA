using ACMA.Domain.Entities.Common;
using ACMA.Models.Authorize;
using ACMA.Models.User;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using userDomain = ACMA.Domain.Entities.Access;

namespace ACMA.AutoMapper
{
    public class ModelToDomainMappingProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<LoginModel, userDomain.User>();
            Mapper.CreateMap<UpdateUserModel, userDomain.User>().ConstructUsing(ConvertUpdateUserModelToDomain);
            Mapper.CreateMap<RegisterUserModel, userDomain.User>().ConstructUsing(ConvertRegisterUserModelToDomain);
        }

        private static userDomain.User ConvertUpdateUserModelToDomain(UpdateUserModel updateUserModel)
        {
            return new userDomain.User()
            {
                UserName = updateUserModel.UserName,
                Password = updateUserModel.Password,
                IdProfile = updateUserModel.IdSelectListProfile,
                Contact = new Contact()
                {
                    FullName = updateUserModel.FullName,
                    Email = updateUserModel.Email,
                    Phone = updateUserModel.Phone
                },
                Blocked = updateUserModel.Blocked,
                Active = updateUserModel.Active
            };
        }

        private static userDomain.User ConvertRegisterUserModelToDomain(RegisterUserModel registerUserModel)
        {
            return new userDomain.User()
            {
                UserName = registerUserModel.UserName,
                Password = registerUserModel.Password,
                IdProfile = registerUserModel.IdSelectListProfile,
                Contact = new Contact()
                {
                    FullName = registerUserModel.FullName,
                    Email = registerUserModel.Email,
                    Phone = registerUserModel.Phone
                }
            };
        }
    }
}
