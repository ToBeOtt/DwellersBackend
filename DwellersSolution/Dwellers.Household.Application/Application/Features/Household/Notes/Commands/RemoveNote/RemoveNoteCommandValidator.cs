using FluentValidation;

namespace Dwellers.Household.Application.Features.Household.Notes.Commands.RemoveNote
{
    public class RemoveNoteCommandValidator : AbstractValidator<RemoveNoteCommand>
    {
        public RemoveNoteCommandValidator()
        {
            RuleFor(command => command.NoteId)
                .NotEmpty().WithMessage("Note ID is required.")
                .GreaterThan(Guid.Empty).WithMessage("Note ID must be valid and greater than Guid.Empty.");
        }
    }
}
