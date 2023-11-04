using Mapster;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Dwellers.Notes.Mappings
{
    public static class NoteMappingDependencyInjection
    {
        public static IServiceCollection AddNoteModuleMappings(this IServiceCollection services)
        {
            var config = TypeAdapterConfig.GlobalSettings;
            config.Scan(Assembly.GetExecutingAssembly());

            services.AddSingleton(config);
            return services;
        }
    }
}
