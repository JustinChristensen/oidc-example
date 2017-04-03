using Owin;
using Serilog;

namespace OidcTest.IdentityServer
{
    public static class Logging
    {
        public static void InitLogging()
        {
            // enable logging
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.LiterateConsole()
                .CreateLogger();
        }

        public static IAppBuilder UseLogging(this IAppBuilder app)
        {
            InitLogging();
            return app;
        }
    }


}