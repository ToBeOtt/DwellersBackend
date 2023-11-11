using Dwellers.Bulletins.Domain.Bulletins;
using Dwellers.Calendar.Application.Interfaces;
using Dwellers.Common.Persistance.BulletinModule.Repositories;
using Dwellers.Common.Persistance.CalendarModule.Interfaces;
using Dwellers.Common.Persistance.CalendarModule.Repositories;
using Dwellers.Common.Persistance.ChatModule.Interfaces;
using Dwellers.Common.Persistance.ChatModule.Repositories;
using Dwellers.Common.Persistance.HouseholdModule.Interfaces.Houses;
using Dwellers.Common.Persistance.HouseholdModule.Interfaces.Users;
using Dwellers.Common.Persistance.HouseholdModule.Repositories.Houses;
using Dwellers.Common.Persistance.HouseholdModule.Repositories.Users;
using Dwellers.Common.Persistance.NotesModule.Interfaces;
using Dwellers.Common.Persistance.NotesModule.Repositories;
using Dwellers.Common.Persistance.OfferingsModule.Interfaces.DwellerItems;
using Dwellers.Common.Persistance.OfferingsModule.Interfaces.DwellerServices;
using Dwellers.Common.Persistance.OfferingsModule.Repositories.DwellerItems;
using Dwellers.Common.Persistance.OfferingsModule.Repositories.DwellerServices;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Dwellers.Common.Persistance
{
    public static class DwellerPersistanceConfig
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            //Repositories
            services.AddTransient<IHouseCommandRepository, HouseCommandRepository>();
            services.AddTransient<IHouseQueryRepository, HouseQueryRepository>();
            services.AddTransient<IUserCommandRepository, UserCommandRepository>();
            services.AddTransient<IUserQueryRepository, UserQueryRepository>();

            services.AddTransient<IDwellerItemCommandRepository, DwellerItemCommandRepository>();
            services.AddTransient<IDwellerItemQueryRepository, DwellerItemQueryRepository>();

            services.AddTransient<IDwellerServiceCommandRepository, DwellerServiceCommandRepository>();
            services.AddTransient<IDwellerServiceQueryRepository, DwellerServiceQueryRepository>();

            services.AddTransient<INoteCommandRepository, NoteCommandRepository>();
            services.AddTransient<INoteQueryRepository, NoteQueryRepository>();

            services.AddTransient<IBulletinRepository, BulletinRepository>();

            services.AddTransient<IChatCommandRepository, ChatCommandRepository>();
            services.AddTransient<IChatQueryRepository, ChatQueryRepository>();

            services.AddTransient<IDwellerEventsCommandRepository, DwellerEventsCommandRepository>();
            services.AddTransient<IDwellerEventsQueryRepository, DwellerEventsQueryRepository>();

            return services;
        }
    }
}
