using System;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using IdentityServer3.Core.Configuration;
using Microsoft.Owin;
using OidcTest.IdentityServer;
using Owin;

[assembly: OwinStartup(typeof(Startup))]

namespace OidcTest.IdentityServer
{
    public class Startup
    {
        public Startup()
        {
            Logging.InitLogging();
        }

        public void Configuration(IAppBuilder app)
        {
            app.UseIdentityServer(new IdentityServerOptions
            {
                SiteName = "Platform OpenId Provider",
                SigningCertificate = LoadCertificate(),

                Factory = new IdentityServerServiceFactory()
                    .UseInMemoryUsers(Users.Get())
                    .UseInMemoryClients(Clients.Get())
                    .UseInMemoryScopes(Scopes.Get())
            });
        }

        private static X509Certificate2 LoadCertificate()
        {
            return new X509Certificate2(
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"bin\idsrv3test.pfx"), "idsrv3test");
        }
    }
}
