using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IdentityServer3.Core.Models;

namespace Server
{
    public static class Scopes
    {
        public static List<Scope> Get()
        {
            // what are we granting access to for this client?
            // client: "I need access to identity data like the resource owner's email and profile
            // and to operate on resources like an api"
            // ScopeType
            //      identity
            //      resource

            return new List<Scope>()
            {
                StandardScopes.OpenId,
                StandardScopes.Profile,
                StandardScopes.Email,

                new Scope()
                {
                    Name = "api",

                    DisplayName = "Sample API Access",
                    Description = "This will grant you access to the Sample API",

                    ScopeSecrets = new List<Secret>
                    {
                        new Secret("api-secret".Sha256())
                    },

                    Type = ScopeType.Resource
                }
            };
        }
    }
}