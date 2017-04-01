using System;
using System.Threading.Tasks;
using System.Web.Http;
using IdentityServer3.AccessTokenValidation;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Owin;

[assembly: OwinStartup(typeof(SampleAPI.Startup))]

namespace SampleAPI
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // allow all origins
            app.UseCors(CorsOptions.AllowAll);

            // token validation
            app.UseIdentityServerBearerTokenAuthentication(new IdentityServerBearerTokenAuthenticationOptions
            {
                // authorization server
                // on startup, this will try to get configuration from
                // .well-known/openid-configuration
                Authority = "https://localhost:44396",
                
                // the client of the authorization server, in this case,
                // is the API itself and so it needs an id and a secret
                ClientId = "api",
                ClientSecret = "api-secret",

                // the resource server specifies that the "api" scope
                // is required to access it's resources
                RequiredScopes = new [] { "api" }
            });

            // web api
            var httpConfig = new HttpConfiguration();
            httpConfig.MapHttpAttributeRoutes();
            httpConfig.Filters.Add(new AuthorizeAttribute());

            app.UseWebApi(httpConfig);
        }
    }
}
