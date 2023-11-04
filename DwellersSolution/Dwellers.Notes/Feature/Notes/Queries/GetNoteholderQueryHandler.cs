using Dwellers.Common.Data.Models.Notes;
using Dwellers.Common.Persistance.OfferingsModule.Interfaces.DwellerItems;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Dwellers.Notes.Feature.Notes.Queries
{
    public record GetNoteholderQuery(
        Guid HouseId,
        Guid NoteholderId) : IRequest<GetNoteholderResult>;
    public record GetNoteholderResult(
       NoteholderEntity Noteholder,
       ICollection<NoteEntity>? Notes);

    public class GetNoteholderQueryHandler : IRequestHandler<GetNoteholderQuery, GetNoteholderResult>
    {
        private readonly ILogger<GetNoteholderQueryHandler> _logger;
        private readonly INoteQueryRepository _noteQueryRepository;

        public GetNoteholderQueryHandler(
            ILogger<GetNoteholderQueryHandler> logger,
            INoteQueryRepository noteQueryRepository)
        {
            _logger = logger;
            _noteQueryRepository = noteQueryRepository;
        }
        public async Task<GetNoteholderResult> Handle(GetNoteholderQuery request, CancellationToken cancellationToken)
        {
            var noteholder = await _noteQueryRepository.GetNoteholderById(request.NoteholderId);
            if (noteholder is null)
            {
                _logger.LogInformation("The noteholder could not be found");
            }
            var relatedNotes = await _noteQueryRepository.GetNotesForNoteholder(request.NoteholderId);

            return new GetNoteholderResult(
                Noteholder: noteholder,
                Notes: relatedNotes);
        }
    }
}
