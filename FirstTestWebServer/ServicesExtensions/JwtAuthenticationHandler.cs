using FirstTest.WebServer.Model.Config;
using FirstTest.WebServer.Service;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Linq;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FirstTest.WebServer.ServicesExtensions
{
    public class JwtAuthenticationHandler : AuthenticationHandler<JwtAuthenticationOptions>
    {
        private SystemConfig config;

        public JwtAuthenticationHandler(
            IOptionsMonitor<JwtAuthenticationOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock, 
            IOptions<SystemConfig> config) : base(options, logger, encoder, clock)
        {
            this.config = config.Value;
        }

        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            string auth = Request.Headers["Authorization"].FirstOrDefault();
            string pattern = @"^[Bb]earer (([A-Za-z0-9\+\/]+\.){2}.+)$";
            MatchCollection matchs = Regex.Matches(auth, pattern);

            if (matchs.Count > 0)
            {
                var token = matchs.First().Groups[1].Value;
                Security.TryValidateToken(config.Secret, token, out ClaimsPrincipal claimsPrincipal);

                var ticket = new AuthenticationTicket(claimsPrincipal,
                    new AuthenticationProperties { IsPersistent = false },
                    Scheme.Name
                );

                return Task.FromResult(AuthenticateResult.Success(ticket));
            }

            return Task.FromResult(AuthenticateResult.NoResult());
        }
    }
}
