using AutoMapper;
using FirstTest.Core.Account;
using FirstTest.Database.FirstTestDB;
using FirstTest.Service.Utility;
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

        public UserDto Register(UserRegisterContent content)
        {
            string pw = Hasher.PasswordHasher(content.Password);
            User user = User.CreateUser(
                content.UserName,
                pw,
                content.Gender);

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

        public UserDto LoginUser(string userName, string password)
        {
            password = Hasher.PasswordHasher(password);

            User user = testDb.Users
                .FirstOrDefault(u => 
                    u.UserName == userName && 
                    u.Password == password);

            return mapper.Map<UserDto>(user);
        }
    }
}
