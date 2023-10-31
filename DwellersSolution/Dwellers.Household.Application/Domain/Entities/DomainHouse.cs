using Microsoft.AspNetCore.Http;

namespace Dwellers.Household.Domain.Entities
{
    public sealed class DomainHouse
    {
        public Guid Id { get; set; }
        public Guid HouseholdCode { get; set; }
        public string Name { get; private set; }
        public string? Description { get; private set; }
        public byte[]? HousePhoto { get; set; }

        public DateTime DateCreated { get; private set; }
        public DateTime? DateUpdated { get; private set; }

        public DomainHouse() { }
        public DomainHouse(
            string name,
            string description)
        {
            Id = Guid.NewGuid();
            Name = name;
            Description = description;
            DateCreated = DateTime.UtcNow;
            HouseholdCode = Guid.NewGuid();
        }

        public async Task<DomainResponse> SetHousePhoto(IFormFile photo)
        {
            DomainResponse response = new();

            try
            {
                using (var memoryStream = new MemoryStream())
                {
                    await photo.CopyToAsync(memoryStream);
                    byte[] imageData = memoryStream.ToArray();

                    HousePhoto = imageData;
                    response.IsSuccess = true;
                    return response;
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.DomainErrorResponse = "Photo could not be added.";
                return response;
            }
        }
    }
}
