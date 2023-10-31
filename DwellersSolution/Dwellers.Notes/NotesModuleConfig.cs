using Dwellers.Notes.Application.Interfaces;
using Dwellers.Notes.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Dwellers.Notes
{
    public static class NotesModuleConfig
    {
        public static IServiceCollection AddNotesModuleServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<INoteCommandRepository, NoteCommandRepository>();
            services.AddTransient<INoteQueryRepository, NoteQueryRepository>();

            return services;
        }
    }
}
