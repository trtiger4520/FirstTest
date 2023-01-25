using FirstTest.Service.Account;
using FirstTest.WebServer.Model.Login;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Concurrent;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FirstTest.WebServer.Service;

public static class Security
{
    private static readonly ConcurrentDictionary<string, string> refreshTokens =
        new();

    private const string Algorithms = SecurityAlgorithms.HmacSha256;
    public static TokenValidationParameters TokenValidationParameters(string secret) => new()
    {
        ValidateAudience = false,
        ValidateIssuer = false,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secret)),
        ValidateLifetime = false
    };

    public static BearerToken GenerateBearerToken(string secret, TimeSpan expires, UserDto user)
    {
        var token = GenerateJwtToken(secret, expires, UserClaim(user));
        var refreshToken = Guid.NewGuid().ToString("n");

        refreshTokens.TryAdd(refreshToken, token);

        return BearerToken.Create(
            token,
            expires.Seconds,
            refreshToken);
    }

    public static BearerToken RefreshToken(string secret, TimeSpan expires, string refreshToken)
    {
        if (!refreshTokens.TryGetValue(refreshToken, out string tokenString))
            throw new RefreshTokenNotFoundException();

        var tokenHandler = new JwtSecurityTokenHandler();
        var tokenParams = TokenValidationParameters(secret);
        var principal = tokenHandler.ValidateToken(
            tokenString,
            tokenParams,
            out SecurityToken securityToken);

        if (securityToken is not JwtSecurityToken jwtSecurityToken ||
            !jwtSecurityToken.Header.Alg.Equals(Algorithms, StringComparison.InvariantCultureIgnoreCase))
        {
            throw new SecurityTokenException("Invalid token");
        }

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(principal.Claims),
            NotBefore = DateTime.UtcNow,
            Expires = DateTime.UtcNow.AddTicks(expires.Ticks),
            SigningCredentials = new SigningCredentials(
                tokenParams.IssuerSigningKey,
                Algorithms)
        };

        var token = tokenHandler.CreateJwtSecurityToken(tokenDescriptor);

        var newTokenString = tokenHandler.WriteToken(token);
        var newRefreshToken = Guid.NewGuid().ToString("n");

        refreshTokens.TryRemove(refreshToken, out string oldToken);
        refreshTokens.TryAdd(newRefreshToken, newTokenString);

        return BearerToken.Create(
            newTokenString,
            expires.Seconds,
            newRefreshToken);
    }

    public static bool TryValidateToken(string secret, string token, out ClaimsPrincipal claimsPrincipal)
    {
        var tokenHandler = new JwtSecurityTokenHandler();

        claimsPrincipal = tokenHandler.ValidateToken(token,
            TokenValidationParameters(secret),
            out SecurityToken securityToken);

        return securityToken is JwtSecurityToken jwtSecurityToken &&
            jwtSecurityToken.Header.Alg.Equals(Algorithms, StringComparison.InvariantCultureIgnoreCase);
    }

    private static string GenerateJwtToken(string secret, TimeSpan expires, IEnumerable<Claim> claims)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(secret);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            NotBefore = DateTime.UtcNow,
            Expires = DateTime.UtcNow.AddTicks(expires.Ticks),
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(key),
                Algorithms)
        };

        var token = tokenHandler.CreateJwtSecurityToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }

    private static Claim[] UserClaim(UserDto user)
    {
        return new Claim[]
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.UserName),
            //new Claim(ClaimTypes.Email, user.Email),
        };
    }
}
