using System;
using MediatR;

namespace SharedKernel.Domain.DomainModels
{
    public interface IDomainEvent : INotification
    {
        Guid Id { get; }

        DateTime OccurredOn { get; }
    }
}