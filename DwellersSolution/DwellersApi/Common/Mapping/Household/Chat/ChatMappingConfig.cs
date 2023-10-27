using Dwellers.Household.Application.Features.Household.Chat.Commands;
using Dwellers.Household.Application.Features.Household.Chat.Queries;
using Dwellers.Household.Contracts.Requests.Household.Chat;
using Dwellers.Household.Contracts.Responses.Household.Chat;
using Mapster;

namespace DwellersApi.Common.Mapping.Household.Chat
{
    public class ChatMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            // Request => Command / Query
            config.NewConfig<SaveMessageRequest, SaveMessageCommand>();
            config.NewConfig<GetHouseholdConversationRequest, GetHouseholdConversationQuery>();

            // Result => Response
            config.NewConfig<SaveMessageResult, SaveMessageResponse>()
               .Map(dest => dest, src => src);
            config.NewConfig<GetHouseholdConversationResult, GetHouseholdConversationResponse>()
               .Map(dest => dest, src => src);
        }
    }
}
