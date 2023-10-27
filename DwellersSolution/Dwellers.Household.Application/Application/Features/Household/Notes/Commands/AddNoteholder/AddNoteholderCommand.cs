using Dwellers.Household.Domain.ValueObjects;
using MediatR;

namespace Dwellers.Household.Application.Features.Household.Notes.Commands.AddNoteholder
{
    public record AddNoteholderCommand(
        Guid houseID,
        string? Category,
        string? NoteholderScope,
        string Name) : IRequest<AddNoteholderResult>;
}