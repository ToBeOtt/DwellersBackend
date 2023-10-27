using Dwellers.Household.Application.Exceptions;
using Dwellers.Household.Application.Interfaces.Household.Meetings;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Dwellers.Household.Application.Features.Household.Notes.Queries.GetNotes
{
    public class GetNotesQueryHandler : IRequestHandler<GetNotesQuery, GetNotesResult>
    {
        private readonly ILogger<GetNotesQueryHandler> _logger;
        private readonly INoteQueryRepository _noteQueryRepository;

        public GetNotesQueryHandler(
            ILogger<GetNotesQueryHandler> logger,
            INoteQueryRepository noteQueryRepository)
        {
            _logger = logger;
            _noteQueryRepository = noteQueryRepository;
        }
        public async Task<GetNotesResult> Handle(GetNotesQuery query, CancellationToken cancellationToken)
        {
            if (query.NoteCategory == null)
            {
                var notes = await _noteQueryRepository.GetNotes(query.HouseId);

                if (notes is null)
                {
                    _logger.LogInformation("Note could not be found");
                    throw new EntityNotFoundException("No meetingpoints could be associated with this household.");
                }

                return new GetNotesResult(
                 Notes: notes
                 );
            }

            var sortedNotes = await _noteQueryRepository.SortNotesByCategory(query.HouseId, query.NoteCategory);
            if (sortedNotes is null)
            {
                _logger.LogInformation("Notes could not be found or no notes existed in that category");
                throw new EntityNotFoundException("Notes could not be found.");
            }

            return new GetNotesResult(
                Notes: sortedNotes
                );
        }
    }
}
