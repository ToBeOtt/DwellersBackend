using Dwellers.Household.Application.Exceptions;
using Dwellers.Household.Application.Interfaces.Household.Meetings;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Dwellers.Household.Application.Features.Household.Notes.Queries.GetNoteholder
{
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
