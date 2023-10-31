﻿using Dwellers.Chat.Application.Interfaces;
using Dwellers.Common.DAL.Context;
using Dwellers.Common.DAL.Models.DwellerChat;
using Microsoft.EntityFrameworkCore;

namespace Dwellers.Chat.Infrastructure.Repositories
{
    public class ChatQueryRepository : IChatQueryRepository
    {
        private readonly DwellerDbContext _context;

        public ChatQueryRepository(
            DwellerDbContext context)
        {
            _context = context;
        }

        public async Task<DwellerConversationEntity> GetConversation(Guid conversationId)
        {
            return 
                await _context.DwellerConversations
                .Where(c => c.Id == conversationId)
                .SingleOrDefaultAsync();
        }

        public async Task<ICollection<DwellerMessageEntity>> GetConversationMessages(Guid conversationId)
        {
            return 
                await _context.DwellerMessages
                .Where(dm => dm.Conversation.Id == conversationId)
                .ToListAsync();
        }

        public async Task<DwellerConversationEntity> GetHouseholdConversation(Guid houseId)
        {
            return 
                await _context.DwellerConversations
                .Include(dc => dc.HouseConversations)
                .Where(dc => dc.HouseConversations
                    .Any(hc => hc.HouseId == houseId))
                    .SingleOrDefaultAsync();
        } 
    }
}