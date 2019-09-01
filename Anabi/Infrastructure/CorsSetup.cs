using Microsoft.AspNetCore.Builder;

namespace Anabi.Infrastructure
{
    public static class CorsSetup
    {
        public static void UseAnabiCorsSetup(this IApplicationBuilder app)
        {
            app.UseCors(builder =>
                builder.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod());
        }
    }
}
