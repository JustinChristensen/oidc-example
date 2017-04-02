using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using IdentityServer3.Core.Models;

namespace Server
{
    public static class Clients
    {
        public static IEnumerable<Client> Get()
        {
            return new[]
            {
                new Client()
                {
                    Enabled = true,
                    ClientName = "OIDC Implicit Client Application",
                    ClientUri = "http://localhost:56668",
                    ClientId = "js",
                    Flow = Flows.Implicit,

                    
                    // default is 1 hour
                    AccessTokenLifetime = 30,
                    
                    // valid redirect URIs for this client
                    // when doing things like signing in this is checked
                    RedirectUris = new List<string>()
                    {
                        "http://localhost:56668",
                        "http://localhost:56668/silent-renew.html"
                    },

                    // redirect uris for logging out
                    PostLogoutRedirectUris = new List<string>()
                    {
                        "http://localhost:56668"
                    },

                    AllowedCorsOrigins = new List<string>()
                    {
                        "http://localhost:56668"
                    },

                    AllowAccessToAllScopes = true
                }
            };
        }
    }
}