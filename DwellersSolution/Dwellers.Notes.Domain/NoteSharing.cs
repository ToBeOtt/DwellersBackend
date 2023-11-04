using Dwellers.Notes.Domain.ValueObjects;
using SharedKernel.Domain.DomainModels;
using SharedKernel.Domain.DomainResponse;

namespace Dwellers.Notes.Domain
{
    public class NoteSharing : BaseEntity
    {
        public IEnumerable<object> User { get; private set; }
        public IEnumerable<object> Houses { get; private set; }

        public Visibility NoteScope {  get; private set; }

        public NoteSharing(int NoteScope)
        {
            SetNoteScope(NoteScope);
        }

        // DomainEvent som notifierar alla med samma Scope att något nytt postats.

        public async Task<DomainResponse<bool>> SetNoteScope(int scope)
        {
            DomainResponse<bool> response = new();
            try
            {
                NoteScope = Visibility.FromDbValue(scope);
                return await response.SuccessResponse(response);
            }
            catch (ArgumentException ex)
            {
                return await response.ErrorResponse(response, "Could not convert status");
            }
        }

    }
}
