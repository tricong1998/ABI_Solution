using ABI_Server.Models;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.Owin;
using System.Web;
using Microsoft.AspNet.Identity;
using System.Security.Principal;

namespace ABI_Server.Provider
{
    public class ApplicationOAuthProvider : OAuthAuthorizationServerProvider
    {
        private readonly string _publicClientId;

        public ApplicationOAuthProvider(string publicClientId)
        {
            if (publicClientId == null)
            {
                throw new ArgumentNullException("publicClientId");
            }

            _publicClientId = publicClientId;
        }

        private void HandleError(OAuthGrantResourceOwnerCredentialsContext context)
        {
            context.SetError("invalid_grant", "The params are incorrect.");
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            // data contains 2 params: exam_id, secret_code
            var data = await context.Request.ReadFormAsync();
            if (data.Count() < 2)
            {
                HandleError(context);
                return;
            }
            if (data["exam_id"] == null || data["secret_code"] == null)
            {
                HandleError(context);
                return;
            }
            var entity = new abiexam_dbEntities();
            int exam_id = Int32.Parse(data["exam_id"]);
            var exam = entity.exams.FirstOrDefault(s => s.id == exam_id && s.active == 1);
            if (exam == null)
            {
                context.SetError("invalid_grant", "incorrect params");
                return;
            }

            //ClaimsIdentity oAuthIdentity = await user.GenerateUserIdentityAsync(userManager,
            //   OAuthDefaults.AuthenticationType);
            //ClaimsIdentity cookiesIdentity = await user.GenerateUserIdentityAsync(userManager,
            //    CookieAuthenticationDefaults.AuthenticationType);

            //AuthenticationProperties properties = CreateProperties(exam.id + "");
            //AuthenticationTicket ticket = new AuthenticationTicket(oAuthIdentity, properties);
            //context.Validated(ticket);

            //var claims = new List<Claim>();
            //claims.Add(new Claim(ClaimTypes.Name, "Brock"));
            //claims.Add(new Claim(ClaimTypes.Email, "brockallen@gmail.com"));
            //var id = new ClaimsIdentity(claims, DefaultAuthenticationTypes.ApplicationCookie);

            //context.Request.Context.Authentication.SignIn(id);

            var identity = new ClaimsIdentity(new GenericIdentity(
                "exam_id", OAuthDefaults.AuthenticationType),
                context.Scope.Select(x => new Claim("urn:oauth:scope", x))
                );

            context.Validated(identity);
        }

        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            foreach (KeyValuePair<string, string> property in context.Properties.Dictionary)
            {
                if (property.Key != null && property.Value != null)
                    context.AdditionalResponseParameters.Add(property.Key, property.Value);
            }

            return Task.FromResult<object>(null);
        }

        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            // Resource owner password credentials does not provide a client ID.
            if (context.ClientId == null)
            {
                context.Validated();
            }

            return Task.FromResult<object>(null);
        }

        public override Task ValidateClientRedirectUri(OAuthValidateClientRedirectUriContext context)
        {
            if (context.ClientId == _publicClientId)
            {
                Uri expectedRootUri = new Uri(context.Request.Uri, "/");

                if (expectedRootUri.AbsoluteUri == context.RedirectUri)
                {
                    context.Validated();
                }
            }

            return Task.FromResult<object>(null);
        }

        public static AuthenticationProperties CreateProperties(string userName)
        {
            IDictionary<string, string> data = new Dictionary<string, string>
            {
                { "userName", userName }
            };
            return new AuthenticationProperties(data);
        }
    }
}