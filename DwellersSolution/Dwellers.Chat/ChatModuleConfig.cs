using Dwellers.Chat.Application.Interfaces;
using Dwellers.Chat.Infrastructure.Data;
using Dwellers.Chat.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
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
            services.AddDbContext<ChatDbContext>(options => options.UseSqlServer
            (connectionString, x => x.MigrationsHistoryTable("__chatModuleMigrationsHistory", "DwellerChatSchema")));

            services.AddTransient<IChatCommandRepository, ChatCommandRepository>();
            services.AddTransient<IChatQueryRepository, ChatQueryRepository>();
  
            // SignalR
            services.AddSignalRCore();

            return services;
        }

        public class ChatDbContextFactory : IDesignTimeDbContextFactory<ChatDbContext>
        {
            public ChatDbContext CreateDbContext(string[] args)
            {
                // Get the configuration from appsettings.json
                IConfiguration configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();;

                // Get the connection string from the configuration
                var connectionString = configuration.GetConnectionString("DefaultConnection");

                // Create DbContextOptions using the connection string
                var optionsBuilder = new DbContextOptionsBuilder<ChatDbContext>()
                    .UseSqlServer(connectionString, x => x.MigrationsHistoryTable
                    ("__chatModuleMigrationsHistory", "ChatModuleSchema"));

                return new ChatDbContext(optionsBuilder.Options);
            }
        }
    }
}
