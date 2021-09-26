using System;

namespace FirstTest.Service.Account
{
    public interface IUserService
    {
        UserDto Register(UserRegisterContent content);
        UserDto GetUser(Guid id);
        UserDto FindUser(string userName, string password);
    }
}