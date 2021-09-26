namespace FirstTest.WebServer.Model.Login
{
    public interface IToken
    {
        string Type { get; }
        string Token { get; }
        int ExpiresIn { get; }
        string RefreshToken { get; }
    }
}
