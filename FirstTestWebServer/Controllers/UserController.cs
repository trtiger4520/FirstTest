using FirstTest.Service.Account;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace FirstTest.WebServer.Controllers
{
    [Route("User")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        /// <summary>
        /// 建立新使用者
        /// </summary>
        /// <param name="name">名稱</param>
        /// <returns></returns>
        [HttpPost, Route("Create")]
        public UserDto CreateUser(string name)
        {
            return userService.Add(new UserDto() { 
                UserName = name,
            });
        }

        /// <summary>
        /// 取得使用者資訊
        /// </summary>
        /// <param name="userid">使用者ID</param>
        /// <returns></returns>
        [HttpGet("{userid}")]
        public UserDto GetUser(string userid)
        {
            return userService.GetUser(Guid.Parse(userid));
        }
    }
}
