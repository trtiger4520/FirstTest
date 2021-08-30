using AutoMapper;
using FirstTest.Core.Account;
using FirstTest.Service.Account;

namespace FirstTest.Service
{
    public class Map : Profile
    {
        public Map()
        {
            CreateMap<User, UserDto>();
            CreateMap<Address, AddressDto>();
        }
    }
}
