using Microsoft.AspNetCore.Http;
using SharedKernel.Domain;
using SharedKernel.Domain.DomainModels;

namespace Dwellers.Household.Domain.Entities
{
    public sealed class DwellerHouse: BaseEntity
    {
        public Guid HouseholdCode { get; set; }
        public string Name { get; private set; }
        public string? Description { get; private set; }
        public byte[]? HousePhoto { get; set; }


        public DwellerHouse() 
        {
            Id = Guid.NewGuid();
            IsCreated = DateTime.Now;
            IsArchived = false;
            HouseholdCode = Guid.NewGuid();
        }

        public DomainResponse<bool> SetName(string name, List<string> existingNames)
        {
            DomainResponse<bool> response = new();

            if (!existingNames.Contains(name))
            {
                Name = name;
                response.IsSuccess = true;
            }
            else
            {
                response.IsSuccess = false;
                response.DomainErrorResponse = "Housename must be unique.";
            }

            return response;
        }

        public void SetDescription(string desc)
        {
            DomainResponse<bool> response = new();
            Description = desc;
        }

        protected async Task<DomainResponse<bool>> SetHousePhoto(IFormFile photo)
        {
            DomainResponse<bool> response = new();

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
