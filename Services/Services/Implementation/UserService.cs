using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Entities;
using Services.Authentication;
using Services.Dtos.User.Create;
using Services.Dtos.User.Read;
using Services.Dtos.User.Update;
using Services.Models;
using Services.Repositories;
using Services.Services.Abstraction;

namespace Services.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IMapper _mapper;
        public UserService(IUserRepository userRepository, IPasswordHasher passwordHasher, IMapper mapper)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _mapper = mapper;
        }
        public void Create(CreateUserDto userCreation)
        {
            EmailAppUser user = _mapper.Map<CreateUserDto, EmailAppUser>(userCreation);
            user.Password = _passwordHasher.HashPassword(user.Password);
            _userRepository.Create(user);
        }

        public void DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public ReadAllUsersListDto GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<ReadAllUsersListDto> ReadUsers(UserSearchModel searchModel)
        {
            throw new NotImplementedException();
        }

        public void Update(UpdateUserDto userUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
