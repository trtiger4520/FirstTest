﻿using FirstTest.Core.Account;
using FirstTest.Service.Account;
using Mapster;

namespace FirstTest.Service;

public static class ServiceMapper
{
    public static void ConfigServicesMapper(this TypeAdapterConfig config)
    {
        config.NewConfig<User, UserDto>();
        config.NewConfig<Address, AddressDto>();
    }
}