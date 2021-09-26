using FirstTest.Service.Account;

namespace FirstTest.WebServer.Model.Login
{
    public class LoginResult
    {
        private LoginResult() { }

        public bool Status { get; set; }
        public IToken Token { get; set; }
        public UserDto User { get; set; }

        public static LoginResult Success(IToken token, UserDto user)
        {
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
