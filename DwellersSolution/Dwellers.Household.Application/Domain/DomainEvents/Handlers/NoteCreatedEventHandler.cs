using Dwellers.Household.Application.Interfaces.Users;
using Dwellers.Household.Domain.DomainEvents.Events;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dwellers.Household.Domain.DomainEvents.Handlers
{
    public class NoteCreatedEventHandler : INotificationHandler<NoteCreatedEvent>
    {
        private readonly IUserQueryRepository _userQueryRepository;

        public NoteCreatedEventHandler(IUserQueryRepository userQueryRepository)
        {
            _userQueryRepository = userQueryRepository;
        }

        public async Task Handle(NoteCreatedEvent notification, CancellationToken cancellationToken)
        {
            var user = await _userQueryRepository.GetUserById(notification.UserId);
        }
    }
}
