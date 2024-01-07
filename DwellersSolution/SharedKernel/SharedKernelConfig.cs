using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using SharedKernel.Infrastructure.Configuration.Commands;
using SharedKernel.Infrastructure.Configuration.Queries;

namespace SharedKernel
{
    public static class SharedKernelConfig
    {
        public static IServiceCollection AddSharedKernelServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<ICommandDispatcher, CommandDispatcher>();
            services.AddTransient<ICommandHandlerFactory, CommandHandlerFactory>();
            services.AddTransient<IQueryDispatcher, QueryDispatcher>();
            services.AddTransient<IQueryHandlerFactory, QueryHandlerFactory>();

            //services.Scan(selector =>
            //{
            //    selector.FromAssemblies(AppDomain.CurrentDomain.GetAssemblies())
            //            .AddClasses(filter =>
            //            {
            //                filter.AssignableTo(typeof(IQueryHandler<,>));
            //            })
            //            .AsImplementedInterfaces()
            //            .WithTransientLifetime();

            //    selector.FromAssemblies(AppDomain.CurrentDomain.GetAssemblies())
            //            .AddClasses(filter =>
            //            {
            //                filter.AssignableTo(typeof(ICommandHandler<,>));
            //            })
            //            .AsImplementedInterfaces()
            //            .WithTransientLifetime();
            //});
     
            return services;
        }
    }
}
