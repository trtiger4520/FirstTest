using FirstTest.Core.Account;
using Microsoft.AspNetCore.Identity;
using System;

namespace FirstTest.WebServer.Model
{
    public class AppRole : IdentityRole<Guid>, IRole { }
}
