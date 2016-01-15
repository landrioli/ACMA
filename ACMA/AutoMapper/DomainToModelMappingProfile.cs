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
    public class DomainToModelMappingProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<userDomain.User, UpdateUserModel>().ForMember(p => p.FullName, t => t.MapFrom(r => r.Contact.FullName))
                                                                .ForMember(p => p.Email, t => t.MapFrom(r => r.Contact.Email))
                                                                .ForMember(p => p.Phone, t => t.MapFrom(r => r.Contact.Phone));
            Mapper.CreateMap<userDomain.User, GridUserModel>().ForMember(p => p.FullName, t => t.MapFrom(r => r.Contact.FullName))
                                                              .ForMember(p => p.Email, t => t.MapFrom(r => r.Contact.Email))
                                                              .ForMember(p => p.Phone, t => t.MapFrom(r => r.Contact.Phone));
        }
    }
}
