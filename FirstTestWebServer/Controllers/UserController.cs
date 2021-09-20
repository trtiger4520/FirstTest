using FirstTest.Service.Account;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace FirstTest.WebServer.Controllers
{
    [Route("api/User")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> logger;
        private readonly IUserService userService;

        public UserController(ILogger<UserController> logger, IUserService userService)
        {
            this.logger = logger;
            this.userService = userService;
        }

        /// <summary>
        /// 取得使用者資訊
        /// </summary>
        /// <param name="userid">使用者ID</param>
        /// <returns></returns>
        [HttpGet("{userid}")]
        public UserDto GetUser(string userid)
        {
            logger.LogTrace("API {controller}", this.HttpContext.Request.Path);
            return userService.GetUser(Guid.Parse(userid));
        }
    }
}
