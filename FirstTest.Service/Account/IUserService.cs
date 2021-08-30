using System;

namespace FirstTest.Service.Account
{
    public interface IUserService
    {
        UserDto Add(UserDto userDto);
        UserDto GetUser(Guid id);
    }
}