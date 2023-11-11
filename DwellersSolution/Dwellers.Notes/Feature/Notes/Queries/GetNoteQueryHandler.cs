using Dwellers.Common.Data.Models.Notes;
using Dwellers.Common.Persistance.OfferingsModule.Interfaces.DwellerItems;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Dwellers.Notes.Feature.Notes.Queries
{
    public record GetNoteQuery(
       Guid NoteId) : IRequest<GetNoteResult>;
    public record GetNoteResult(
       NoteEntity Note);

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
            }
            return new GetNoteResult(
                Note: note);
        }
    }
}
