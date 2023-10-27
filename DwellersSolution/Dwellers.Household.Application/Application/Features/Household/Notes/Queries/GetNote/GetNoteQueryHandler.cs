using Dwellers.Household.Application.Exceptions;
using Dwellers.Household.Application.Interfaces.Household.Meetings;
using MediatR;
using Microsoft.Build.Framework;
using Microsoft.Extensions.Logging;
using Microsoft.Graph.Drives.Item.Items.Item.Workbook.Worksheets.Item.Charts.Item.ImageWithWidthWithHeightWithFittingMode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dwellers.Household.Application.Features.Household.Notes.Queries.GetNote
{
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
