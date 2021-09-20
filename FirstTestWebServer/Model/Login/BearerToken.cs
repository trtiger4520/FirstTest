namespace FirstTest.WebServer.Model.Login
{
    public class BearerToken
    {
        public string Type { get; set; }
        public string Token { get; set; }
        public int ExpiresIn { get; set; }
        public string RefreshToken { get; set; }
    }
}
