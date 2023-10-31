using Dwellers.Common.DAL.Models.Notes;

namespace Dwellers.Notes.Contracts.Responses
{
    public record GetNoteholdersResponse(
        ICollection<NoteholderEntity> Noteholders);
}
