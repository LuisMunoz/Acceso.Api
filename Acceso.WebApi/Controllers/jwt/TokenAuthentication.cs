using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Security.Claims;

namespace Acceso.Seguridad.API.Controllers
{
    internal class TokenAuthentication
    {
        public Boolean Authentication(string token)
        {
            try
            {
                var principal = AuthenticateJwtToken(token);
                if (principal == null)
                {
                    return false;
                }
                else
                    return true;
            }
            catch (Exception)
            {
                return false;
            }
            
        }


        public Task<IPrincipal> AuthenticateJwtToken(string token)
        {
            string username;

            if (ValidateToken(token, out username))
            {
                // based on username to get more information from database in order to build local identity
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, username)
                    // Add more claims if needed: Roles, ...
                };

                var identity = new ClaimsIdentity(claims, "Jwt");
                IPrincipal user = new ClaimsPrincipal(identity);

                return Task.FromResult(user);
            }

            return Task.FromResult<IPrincipal>(null);
        }

        private static bool ValidateToken(string token, out string username)
        {
            username = null;

            var simplePrinciple = JwtManager.GetPrincipal(token);
            if (simplePrinciple != null)
            {
                var identity = simplePrinciple.Identity as ClaimsIdentity;

                if (identity == null)
                    return false;

                if (!identity.IsAuthenticated)
                    return false;

                var usernameClaim = identity.FindFirst(ClaimTypes.Name);
                username = usernameClaim?.Value;

                if (string.IsNullOrEmpty(username))
                    return false;

                // More validate to check whether username exists in system

                return true;
            }
            else { return false; }
            

            
        }
    }
}