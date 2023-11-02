using Dwellers.Common.Data.Models.Common.ValueObjects;
using Microsoft.AspNetCore.Http;

namespace Dwellers.Offerings.Domain.Entities.DwellerItems
{
    public sealed class DomainDwellerItem
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        public VisibilityScope ItemScope { get; private set; }
        public byte[]? ItemPhoto { get; private set; }
        public bool ItemStatus { get; private set; }
        public DateTime? DateAdded { get; private set; }


        public DomainDwellerItem() { }

        public DomainDwellerItem(string name, string desc)
        {
            Id = Guid.NewGuid();
            Name = name;
            Description = desc;
            ItemStatus = true;
            DateAdded = DateTime.UtcNow;
        }
        public DomainResponse SetItemScope(string scope)
        {
            DomainResponse response = new();
            if (Enum.TryParse(scope, out VisibilityScope itemscope))
            {
                ItemScope = itemscope;
                response.IsSuccess = true;
                return response;
            }
            response.IsSuccess = false;
            response.DomainErrorResponse = "Scope could not be parsed to enum.";
            return response;
        }

        public async Task<DomainResponse> SetItemPhoto(IFormFile photo)
        {
            DomainResponse response = new();

            try
            {
                using (var memoryStream = new MemoryStream())
                {
                    await photo.CopyToAsync(memoryStream);
                    byte[] imageData = memoryStream.ToArray();

                    ItemPhoto = imageData;
                    response.IsSuccess = true;
                    return response;
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.DomainErrorResponse = "Photo could not be added to item.";
                return response;
            }
        }
    }
}
