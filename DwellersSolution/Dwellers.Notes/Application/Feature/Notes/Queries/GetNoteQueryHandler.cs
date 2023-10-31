using Dwellers.Notes.Domain;
using Microsoft.Extensions.Logging;

namespace Dwellers.Notes.Application.Feature.Notes.Queries
{
    public record GetNoteQuery(
       Guid NoteId) : IRequest<GetNoteResult>;
    public record GetNoteResult(
       Note Note);

    public class GetNoteQueryHandler : IRequestHandler<GetNoteQuery, GetNoteResult>
    {
        private readonly ILogger<GetNoteQueryHandler> _logger;
        private readonly INoteQueryRepository _noteQueryRepository;

        public GetNoteQueryHandler(
            ILogger<GetNoteQueryHandler> logger,
            INoteQueryRepository noteQueryRepository)
        {
            _logger = logger;
            _noteQueryRepository = noteQueryRepository;
        }
        public async Task<GetNoteResult> Handle(GetNoteQuery request, CancellationToken cancellationToken)
        {
            var note = await _noteQueryRepository.GetNoteById(request.NoteId);
            if (note is null)
            {
                _logger.LogInformation("The note could not be found");
                throw new EntityNotFoundException("Note could not be found");
            }
            return new GetNoteResult(
                Note: note);
        }
    }
}
