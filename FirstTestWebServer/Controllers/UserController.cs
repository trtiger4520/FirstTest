using FirstTest.Service.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace FirstTest.WebServer.Controllers
{
    [Authorize]
    [Route("api/v{version:apiVersion}/User")]
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
        [ApiVersion("1.0")]
        public IActionResult GetUser(string userid)
        {
            logger.LogTrace("API {controller}", this.HttpContext.Request.Path);
            var user = userService.GetUser(Guid.Parse(userid));

            if (user is null)
                return NotFound(null);

            return Ok(user);
        }
    }
}
