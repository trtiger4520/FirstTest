using FirstTest.Service.Account;
using FirstTest.WebServer.Model.Config;
using FirstTest.WebServer.Model.Login;
using FirstTest.WebServer.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;

namespace FirstTest.WebServer.Controllers
{
    [Route("api/v{version:apiVersion}/Account")]
    [ApiController]
    public class AccountController : Controller
    {
        private readonly SystemConfig systemConfig;
        private readonly IUserService userService;

        public AccountController(IOptions<SystemConfig> systemConfig, IUserService userService)
        {
            this.systemConfig = systemConfig.Value;
            this.userService = userService;
        }

        /// <summary>
        /// 建立新使用者
        /// </summary>
        /// <param name="content">註冊內容</param>
        /// <returns></returns>
        [HttpPost, Route("Register")]
        [ApiVersion("1.0")]
        public UserDto Register(UserRegisterContent content)
        {
            return userService.Register(content);
        }

        /// <summary>
        /// 登入
        /// </summary>
        /// <param name="content">登入資訊</param>
        /// <returns></returns>
        [HttpPost, Route("Login")]
        [ApiVersion("1.0")]
        public LoginResult Login(LoginContent content)
        {
            var user = userService.FindUser(content.UserName, content.Password);

            if (user is null)
                return LoginResult.False();

            var expires = TimeSpan.FromDays(content.RememberMe ? 3 : 1);
            var bearerToken = Security.GenerateBearerToken(
                systemConfig.Secret,
                expires,
                user);

            return LoginResult.Success(bearerToken, user);
        }

        [Authorize]
        [HttpPost, Route("RefreshToken")]
        [ApiVersion("1.0")]
        public IToken RefreshToken(string refreshToken)
        {
            var expires = TimeSpan.FromDays(7);
            return Security.RefreshToken(systemConfig.Secret, expires, refreshToken);
        }
    }
}
