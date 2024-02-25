﻿using Dwellers.Common.Application.Contracts.Queries.Chats;
using Dwellers.Common.Application.Contracts.Results.Chats;
using Dwellers.Common.Application.Contracts.Results.Chats.DTOs;
using Dwellers.Common.Application.Interfaces.Chats;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Graph.Models;
using SharedKernel.Infrastructure.Configuration.Queries;
using SharedKernel.ServiceResponse;

namespace Dwellers.Common.Application.Queries.Chats.GetDwellingConversation
{
    public class GetDwellingConversationQueryHandler(IChatQueryRepository chatQuery)
        : IQueryHandler<GetDwellingConversationQuery, GetDwellingConversationResult>
    {
        private readonly IChatQueryRepository _chatQuery = chatQuery;

        public async Task<DwellerResponse<GetDwellingConversationResult>> Handle
            (GetDwellingConversationQuery query, CancellationToken cancellation)
        {
            DwellerResponse<GetDwellingConversationResult> response = new();

            var conversation = await _chatQuery.GetDwellerConversation(query.DwellingId);
            if (conversation == null)
                return await response.ErrorResponse("Conversation could not be found or contained no messages.");

            var messages = await _chatQuery.GetConversationMessages(conversation.Id);
            if (messages is null)
                return await response.ErrorResponse("Conversation could not be found or contained no messages.");

            var messageList = new List<DwellerMessageDto>();
            foreach(var message in messages)
            {
                var messageDto = new DwellerMessageDto(message.Id, message.MessageText, message.IsCreated,
                    message.Dweller.Alias, message.IsRead);
                messageList.Add(messageDto);
            }

            return await response.SuccessResponse(new(
                ConversationId: conversation.Id,
                MessageList: messageList));
        }
    }
}
