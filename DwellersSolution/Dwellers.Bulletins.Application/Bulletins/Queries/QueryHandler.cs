using Dwellers.Bulletins.Domain.Bulletins;
using SharedKernel.Infrastructure.Configuration.Queries;
using static Dwellers.Bulletins.Application.Bulletins.Queries.GetWolfQueryHandler;

namespace Dwellers.Bulletins.Application.Bulletins.Queries
{

    public class GetWolfQueryHandler : IQueryHandler<GetWolfQuery, GetWolfQueryResult>
    {
        public async Task<GetWolfQueryResult> Handle
            (GetWolfQuery query, CancellationToken cancellation)
        {
            return new GetWolfQueryResult(null);
        }

        public record GetWolfQuery(
        Guid WolfId);
        public record GetWolfQueryResult(
        Bulletin wolfBulletin);

    }
}
