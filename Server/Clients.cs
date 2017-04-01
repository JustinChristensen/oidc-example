﻿using System;
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
                    ClientName = "JS Client",
                    ClientId = "js",
                    Flow = Flows.Implicit,

                    
                    // default is 1 hour
                    AccessTokenLifetime = 70,
                    
                    // valid redirect URIs
                    RedirectUris = new List<string>()
                    {
                        "http://localhost:56668",
                        "http://localhost:56668/popup.html",
                        "http://localhost:56668/silent-renew.html"
                    },

                    PostLogoutRedirectUris = new List<string>()
                    {
                        "http://localhost:56668/index.html"
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