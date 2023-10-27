using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dwellers.Household.Domain.DomainEvents.Events
{
    public class NoteCreatedEvent : INotification
    {
        public string UserId { get; set; }
    }
}
