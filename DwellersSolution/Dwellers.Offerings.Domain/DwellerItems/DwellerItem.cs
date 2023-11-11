using Dwellers.Offerings.Domain.ValueObjects;
using Microsoft.AspNetCore.Http;
using SharedKernel.Domain.DomainModels;
using SharedKernel.Domain.DomainResponse;

namespace Dwellers.Offerings.Domain.DwellerItems
{
    public sealed class DwellerItem : BaseEntity
    {
        public Guid Id { get; set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        public VisibilityScope ItemScope { get; private set; }
        public byte[]? ItemPhoto { get; private set; }
        public bool ItemStatus { get; private set; }

        public bool IsArchived { get; set; }
        public DateTime IsCreated { get; set; }
        public DateTime? IsModified { get; set; }

        public DwellerItem()
        {
            Id = Guid.NewGuid();
            IsCreated = DateTime.UtcNow;
            IsArchived = false;
        }

        public DwellerItem(string name, string desc)
        {
            Id = Guid.NewGuid();
            Name = name;
            Description = desc;
            IsCreated = DateTime.UtcNow;
            IsArchived = false;
        }
        public async Task<DomainResponse<bool>> SetItemScope(string scope)
        {
            DomainResponse<bool> response = new();
            if (Enum.TryParse(scope, out VisibilityScope itemscope))
            {
                ItemScope = itemscope;
                return response.SuccessResponse(response);
            }

            return response.ErrorResponse(response, "Scope could not be parsed to enum.");
        }

        public async Task<DomainResponse<bool>> SetItemPhoto(IFormFile photo)
        {
            DomainResponse<bool> response = new();

            try
            {
                using (var memoryStream = new MemoryStream())
                {
                    await photo.CopyToAsync(memoryStream);
                    byte[] imageData = memoryStream.ToArray();

                    ItemPhoto = imageData;
                    return response.SuccessResponse(response);
                }
            }
            catch (Exception ex)
            {
                return response.ErrorResponse(response, ex.Message);
            }
        }
    }
}
