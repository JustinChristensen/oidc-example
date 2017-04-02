using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Serilog;

namespace Server
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