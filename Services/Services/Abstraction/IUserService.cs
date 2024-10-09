using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Services.Dtos.User.Create;
using Services.Dtos.User.Read;
using Services.Dtos.User.Update;
using Services.Models;

namespace Services.Services.Abstraction
{
    public interface IUserService
    {
        void Create(CreateUserDto userCreation);
        void Update(UpdateUserDto userUpdate);
        List<ReadAllUsersListDto> ReadUsers(UserSearchModel searchModel);
        ReadAllUsersListDto GetById(int id);
        void DeleteById(int id);
    }
}
