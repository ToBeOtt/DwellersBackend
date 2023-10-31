using Dwellers.Notes.Domain;
using Microsoft.Extensions.Logging;

namespace Dwellers.Notes.Application.Feature.Notes.Queries
{
    public record GetNoteholderQuery(
        Guid HouseId,
        Guid NoteholderId) : IRequest<GetNoteholderResult>;
    public record GetNoteholderResult(
       Noteholder Noteholder,
       ICollection<Note>? Notes);

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
                throw new EntityNotFoundException("Noteholder could not be found");
            }
            var relatedNotes = await _noteQueryRepository.GetNotesForNoteholder(request.NoteholderId);

            return new GetNoteholderResult(
                Noteholder: noteholder,
                Notes: relatedNotes);
        }
    }
}
