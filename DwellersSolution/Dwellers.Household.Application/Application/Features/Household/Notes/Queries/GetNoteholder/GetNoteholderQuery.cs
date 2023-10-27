using MediatR;

namespace Dwellers.Household.Application.Features.Household.Notes.Queries.GetNoteholder
{
    public record GetNoteholderQuery(
        Guid HouseId,
        Guid NoteholderId) : IRequest<GetNoteholderResult>;
}
