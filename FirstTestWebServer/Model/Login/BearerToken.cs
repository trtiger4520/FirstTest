namespace FirstTest.WebServer.Model.Login
{
    public class BearerToken : IToken
    {
        private BearerToken() { }

        public string Type { get; private set; }

        public string Token { get; private set; }

        public int ExpiresIn { get; private set; }

        public string RefreshToken { get; private set; }

        public static BearerToken Create(string token, int expriesIn, string refreshToken)
        {
            return new BearerToken()
            {
                Type = "Bearer",
                Token = token,
                ExpiresIn = expriesIn,
                RefreshToken = refreshToken,
            };
        }
    }
}
