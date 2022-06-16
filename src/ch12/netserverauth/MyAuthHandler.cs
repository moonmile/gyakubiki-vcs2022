using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using System.Text.Encodings.Web;

namespace netserverauth
{
    class MyAuthHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        public MyAuthHandler(IOptionsMonitor<AuthenticationSchemeOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock) : 
            base(options, logger, encoder, clock)
        {
        }

        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            var apikey = this.Context.Request.Headers["X-API-KEY"].ToString();
            if ( apikey == "XXXX-XXXX-XXXX")
            {
                var ticket = new AuthenticationTicket(
                    new ClaimsPrincipal(new ClaimsIdentity(new[]
                    {
                        new Claim("name","admin")
                    }, "authtype")), "xapi");
                return Task.FromResult<AuthenticateResult>(AuthenticateResult.Success(ticket));
            }
            else
            {
                return Task.FromResult(AuthenticateResult.Fail("Invalid API Key"));
            }

        }
    }
}
