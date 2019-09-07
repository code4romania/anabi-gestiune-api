using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;

namespace Anabi.Infrastructure
{
    public static class LoggingServices
    {
        public static void AddAnabiLoggingServices(this IServiceCollection services)
        {
            services.AddLogging(loggingBuilder =>
                                    loggingBuilder
                                    .AddSerilog(dispose: true)
                                    .AddConsole());
        }
    }
}
