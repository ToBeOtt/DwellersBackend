using Dwellers.Chat.Domain.Entities;
using Dwellers.Common.Data.Context;
using Dwellers.Common.Data.Models.DwellerChat;
using Dwellers.Common.Persistance.ChatModule.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Dwellers.Common.Persistance.ChatModule.Repositories
{
    public class ChatCommandRepository : BaseRepository, IChatCommandRepository
    {
        private readonly DwellerDbContext _context;
        private readonly ILogger<ChatCommandRepository> _logger;

        public ChatCommandRepository(
            DwellerDbContext context,
            ILogger<ChatCommandRepository> logger) : base(context)
        {
            _context = context;
            _logger = logger;
        }
        private async Task<int> SaveActions()
        {
            try
            {
                return await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                _logger.LogInformation("Error with persistence: " + ex.Message);
                return 0;
            }
            catch (DbUpdateException ex)
            {
                _logger.LogInformation("Error with persistence: " + ex.Message);
                return 0;
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Error with persistence: " + ex.Message);
                return 0;
            }
        }
        public async Task<bool> PersistMessage(Message message)
        {
            _context.Messages.AddAsync(message);
            return await Save();
        }

        public async Task<bool> PersistConversation(Conversation conversation)
        {
            _context.Conversations.AddAsync(conversation);
            return await Save();
        }
        public async Task<bool> PersistHouseConversation(DwellingConversationEntity houseConversation)
        {
            _context.Conversations.AddAsync(houseConversation);
            return await Save();

        }
    }
}