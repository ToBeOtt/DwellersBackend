using Dwellers.Household.Application.Exceptions;
using Dwellers.Household.Application.Interfaces.Household.Meetings;
using Dwellers.Household.Domain.Entities.Notes;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Dwellers.Household.Application.Features.Household.Dashboard.Queries
{
    public record GetDashboardNotesCommand(
        Guid HouseId) : IRequest<GetDashboardNotesResult>;


    public record GetDashboardNotesResult(
        ICollection<Note> Notes,
        ICollection<Noteholder> Noteholders);


    public class GetDashboardNotesCommandHandler : IRequestHandler<GetDashboardNotesCommand, GetDashboardNotesResult>
    {
        private readonly ILogger<GetDashboardNotesCommandHandler> _logger;
        private readonly INoteQueryRepository _noteQueryRepository;

        public GetDashboardNotesCommandHandler(
            ILogger<GetDashboardNotesCommandHandler> logger,
            INoteQueryRepository noteQueryRepository)
        {
            _logger = logger;
            _noteQueryRepository = noteQueryRepository;
        }

        public async Task<GetDashboardNotesResult> Handle(GetDashboardNotesCommand cmd, CancellationToken cancellationToken)
        {
            var notes = await _noteQueryRepository.GetNewOrUpdatedNotes(cmd.HouseId);
            if (notes is null)
            {
                _logger.LogInformation("Notes could not be found");
                throw new EntityNotFoundException("No notes could be associated with this household.");
            }

            var noteholders = await _noteQueryRepository.GetNewOrUpdatedNoteholders(cmd.HouseId);
            if (noteholders is null)
            {
                _logger.LogInformation("Noteholders could not be found");
                throw new EntityNotFoundException("No noteholders could be associated with this household.");
            }

            return new GetDashboardNotesResult(
                Notes: notes,
                Noteholders: noteholders
            );

        }
    }

}
