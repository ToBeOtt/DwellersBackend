using Dwellers.Notes.Domain.ValueObjects;
using SharedKernel.Domain.DomainResponse;

namespace Dwellers.Notes.Domain
{
    internal class FilteringNotesEntity
    {

        public List<string> Tags { get; private set; } = new List<string>();
        public NoteStatus? NoteStatus { get; private set; }


        public FilteringNotesEntity(List<string>? tags, int? status)
        {
            if(tags != null)
            {
                ValidateAndCheckForDuplicates(tags);
            }
            if(status != null)
            {
                var statusValue = status.Value;
                SetNoteStatus(statusValue);
            }
        }

        // När NoteStatus == Done => Notifiera berörda samt IsArchived == true

        public async Task<DomainResponse<bool>> SetNoteStatus(int status)
        {
            DomainResponse<bool> response = new();
            try
            {
                NoteStatus = NoteStatus.FromDbValue(status);
                return await response.SuccessResponse(response);
            }
            catch (ArgumentException ex)
            {
                return await response.ErrorResponse(response, "Could not convert status");
            }
        }

        public async Task<DomainResponse<List<string>>> AddTagToCollection
            (List<string> currentTags, string newTag)
        {
            DomainResponse<List<string>> domainResponse = new();

            List<string> newListOfTags = currentTags;

            var validatedTags = await ValidateAndCheckForDuplicates(newListOfTags);
            if (validatedTags.IsSuccess)
            {
                Tags = validatedTags.DomainData;
                return await domainResponse.SuccessResponse(domainResponse, Tags);
            }

            return await domainResponse.ErrorResponse(domainResponse, "Tag could not be added.");
        }

        public async Task<DomainResponse<List<string>>> ValidateAndCheckForDuplicates
            (List<string> tags)
        {
            DomainResponse<List<string>> domainResponse = new();

            foreach (var tag in tags)
            {
                if (tag.Any(ch => !char.IsLetterOrDigit(ch)))
                    return await domainResponse.ErrorResponse
                        (domainResponse, "Format of hashtag not allowed");

                tag.ToLower();
                var currentTag = tag;
                tags.Remove(currentTag);
                foreach (var duplicate in tags)
                {
                    if (duplicate == currentTag)
                        tags.Remove(duplicate);
                }
                tags.Add(currentTag);
                Tags = tags;
            }

            return await domainResponse.SuccessResponse(domainResponse, Tags);
        }



 
    }
}
