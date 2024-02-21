using Dwellers.Chat.Domain.Entities;
using Dwellers.Common.Application.Interfaces.Chats;
using Dwellers.Common.Infrastructure.Context;
using Microsoft.Extensions.Logging;

namespace Dwellers.Common.Persistance.Repositories.Chats.Repositories
{
    public class ChatCommandRepository : IChatCommandRepository
    {
        private readonly DwellerDbContext _context;
        private readonly ILogger<ChatCommandRepository> _logger;

        public ChatCommandRepository(
            DwellerDbContext context,
            ILogger<ChatCommandRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<bool> PersistMessage(DwellerMessage message)
        {
            try
            {
                await _context.Messages.AddAsync(message);
                return true;
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, ex.Message);
                return false;
            }
        }

        public async Task<bool> PersistConversation(DwellerConversation conversation)
        {
            try
            {
                await _context.Conversations.AddAsync(conversation);
                return true;
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, ex.Message);
                return false;
            } 
        }

        public async Task<bool> PersistMembersInConversation(List<MemberInConversation> listOfMembers)
        {
            try
            {
                foreach(MemberInConversation member in listOfMembers)
                {
                    await _context.MemberInConversations.AddAsync(member);
                }
                return true;
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, ex.Message);
                return false;
            }
            
        }
    }
}