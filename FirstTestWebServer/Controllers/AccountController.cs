using FirstTest.Service.Account;
using FirstTest.WebServer.Model.Config;
using FirstTest.WebServer.Model.Login;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FirstTest.WebServer.Controllers
{
    [Route("api/Account")]
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
        public LoginResult Login(LoginContent content)
        {
            var user = userService.LoginUser(content.UserName, content.Password);

            if (user is null)
                return LoginResult.False();

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(systemConfig.Secret);
            var day = content.RememberMe ? 30 : 7;
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(day),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key), 
                    SecurityAlgorithms.HmacSha512)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);



            return LoginResult.Success(
                tokenString, 
                "Bearer",
                TimeSpan.FromDays(day).Seconds,
                "",
                user);
        }
    }
}
