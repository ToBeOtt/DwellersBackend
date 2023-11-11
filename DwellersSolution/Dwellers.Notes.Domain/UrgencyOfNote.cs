using Dwellers.Notes.Domain.ValueObjects;
using SharedKernel.Domain.DomainResponse;

namespace Dwellers.Notes.Domain
{
    public class UrgencyOfNote
    {
        public NotePriority? NotePriority { get; private set; }

        public UrgencyOfNote(int notePriority)
        {
            SetPriority(notePriority);
        }

        public async Task<DomainResponse<bool>> SetPriority(int priority)
        {
            DomainResponse<bool> response = new();
            try
            {
                NotePriority = NotePriority.FromDbValue(priority);
                return response.SuccessResponse(response);
            }
            catch (ArgumentException ex)
            {
                return response.ErrorResponse(response, "Could not convert status");
            }
        }
    }
}
