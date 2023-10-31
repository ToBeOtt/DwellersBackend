using Dwellers.Chat.Application.Interfaces;
using Dwellers.Chat.Application.Services;
using Dwellers.Chat.Infrastructure.Repositories;
using Dwellers.Common.DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Dwellers.Chat
{
    public static class ChatModuleConfig
    {
        public static IServiceCollection AddChatModuleServices(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection") ??
                throw new InvalidOperationException("Connection string not found.");

            // Makes sure this modules DbContext is used 
            services.AddDbContext<DwellerDbContext>(options => options.UseSqlServer(connectionString));

            services.AddTransient<IChatCommandRepository, ChatCommandRepository>();
            services.AddTransient<IChatQueryRepository, ChatQueryRepository>();

            services.AddTransient<ChatCommandServices>();
            services.AddTransient<ChatQueryServices>();

            // SignalR
            services.AddSignalRCore();

            return services;
        }
    }
}
