using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dwellers.Household.Contracts.Requests.Household.Notes
{
    public record RemoveNoteRequest(
        Guid NoteId);
}
