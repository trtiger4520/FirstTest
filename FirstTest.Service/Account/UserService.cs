using AutoMapper;
using FirstTest.Core.Account;
using FirstTest.Database.FirstTestDB;
using System;
using System.Linq;

namespace FirstTest.Service.Account
{
    public class UserService : IUserService
    {
        private readonly IMapper mapper;
        private readonly TestDBContext testDb;

        public UserService(IMapper mapper, TestDBContext testDb)
        {
            this.mapper = mapper;
            this.testDb = testDb;
        }

        public UserDto Add(UserDto userDto)
        {

            User user = User.CreateUser(
                userDto.UserName, 
                "", 
                Gender.Unisex);

            testDb.Users.Add(user);
            testDb.SaveChanges();

            return mapper.Map<UserDto>(user);
        }

        public UserDto GetUser(Guid id)
        {
            User user = testDb.Users
                .FirstOrDefault(u => Guid.Equals(id, u.Id));

            return mapper.Map<UserDto>(user);
        }
    }
}
