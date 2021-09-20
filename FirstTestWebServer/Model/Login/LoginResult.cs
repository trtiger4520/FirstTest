using FirstTest.Service.Account;

namespace FirstTest.WebServer.Model.Login
{
    public class LoginResult
    {
        private LoginResult() { }

        public bool Status { get; set; }
        public BearerToken Token { get; set; }
        public UserDto User { get; set; }

        public static LoginResult Success(string tokenString, string type, int expiresin, string refreshtoken, UserDto user)
        {
            var token = new BearerToken()
            {
                Type = type,
                Token = tokenString,
                ExpiresIn = expiresin,
                RefreshToken = refreshtoken
            };

            return new LoginResult() {
                Status = true,
                Token = token,
                User = user,
            };
        }
        public static LoginResult False()
        {
            return new LoginResult()
            {
                Status = false,
                Token = null,
                User = null,
            };
        }
    }
}
