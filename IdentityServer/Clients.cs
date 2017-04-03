using System.Collections.Generic;
using IdentityServer3.Core.Models;

namespace OidcTest.IdentityServer
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
                    ClientName = "Ein",
                    ClientUri = "http://ein.devl:56668",
                    ClientId = "ein",
                    Flow = Flows.Implicit,

                    
                    // default is 1 hour
                    AccessTokenLifetime = 30,
                    
                    // valid redirect URIs for this client
                    // when doing things like signing in this is checked
                    RedirectUris = new List<string>()
                    {
                        "http://ein.devl:56668",
                        "http://ein.devl:56668/silent-renew.html"
                    },

                    // redirect uris for logging out
                    PostLogoutRedirectUris = new List<string>()
                    {
                        "http://ein.devl:56668"
                    },

                    AllowedCorsOrigins = new List<string>()
                    {
                        "http://ein.devl:56668"
                    },

                    AllowAccessToAllScopes = true
                },
                new Client()
                {
                    Enabled = true,
                    ClientName = "Zwei",
                    ClientUri = "http://zwei.devl:54448",
                    ClientId = "zwei",
                    Flow = Flows.Implicit,

                    
                    // default is 1 hour
                    AccessTokenLifetime = 30,
                    
                    // valid redirect URIs for this client
                    // when doing things like signing in this is checked
                    RedirectUris = new List<string>()
                    {
                        "http://zwei.devl:54448",
                        "http://zwei.devl:54448/silent-renew.html"
                    },

                    // redirect uris for logging out
                    PostLogoutRedirectUris = new List<string>()
                    {
                        "http://zwei.devl:54448"
                    },

                    AllowedCorsOrigins = new List<string>()
                    {
                        "http://zwei.devl:54448"
                    },

                    AllowAccessToAllScopes = true
                }
            };
        }
    }
}