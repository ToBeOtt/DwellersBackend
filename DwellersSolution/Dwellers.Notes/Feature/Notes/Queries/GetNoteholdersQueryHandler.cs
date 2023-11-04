using Dwellers.Common.Data.Models.Notes;
using Dwellers.Common.Persistance.OfferingsModule.Interfaces.DwellerItems;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Dwellers.Notes.Feature.Notes.Queries
{
    public record GetNoteholdersQuery(
     Guid HouseId) : IRequest<GetNoteholdersResult>;
    public record GetNoteholdersResult(
         ICollection<NoteholderEntity> Noteholders);

    public class GetNoteholdersQueryHandler : IRequestHandler<GetNoteholdersQuery, GetNoteholdersResult>
    {
        private readonly ILogger<GetNotesQueryHandler> _logger;
        private readonly INoteQueryRepository _noteQueryRepository;

        public GetNoteholdersQueryHandler(
            ILogger<GetNotesQueryHandler> logger,
            INoteQueryRepository noteQueryRepository
            )
        {
            _logger = logger;
            _noteQueryRepository = noteQueryRepository;
        }
        public async Task<GetNoteholdersResult> Handle(GetNoteholdersQuery query, CancellationToken cancellationToken)
        {
            var noteholders = await _noteQueryRepository.GetNoteholders(query.HouseId);
            if (noteholders is null)
            {
                _logger.LogInformation("Noteholders could not be found");
            }

            return new GetNoteholdersResult(
                 Noteholders: noteholders
                 );
        }
    }
}
