using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Entities;
using Services.Dtos.Email.Create;
using Services.Dtos.Email.Update;
using Services.Dtos.User.Create;
using Services.Dtos.User.Read;

namespace Services.Mapper.Profiles
{
    public class EntityToDtoProfile: Profile
    {
        public EntityToDtoProfile()
        {
            CreateMap<CreateUserDto, EmailAppUser>().ReverseMap();
            CreateMap<ReadAllUsersListDto, EmailAppUser>().ReverseMap();
            CreateMap<CreateNewEmailDto, Email>().ReverseMap();
            CreateMap<UpdateEmailDto, Email>().ReverseMap();
        }
    }
}
