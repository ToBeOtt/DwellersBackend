using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Dwellers.Notes
{
    public static class NotesModuleConfig
    {
        public static IServiceCollection AddNotesModuleServices(this IServiceCollection services, IConfiguration configuration)
        {
          

            return services;
        }
    }
}
