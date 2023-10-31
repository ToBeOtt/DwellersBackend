using Microsoft.AspNetCore.Http;

namespace Dwellers.Household.Domain.Entities
{
    public sealed class DomainDwellerUser
    {
        public string Id { get; set; }
        public string Alias { get; set; }
        public string Email { get; set; }
        public byte[]? ProfilePhoto { get; set; }

        public DomainDwellerUser() { }


        public async Task<DomainResponse> SetProfilePhoto(IFormFile photo)
        {
            DomainResponse response = new();

            try
            {
                using (var memoryStream = new MemoryStream())
                {
                    await photo.CopyToAsync(memoryStream);
                    byte[] imageData = memoryStream.ToArray();

                    ProfilePhoto = imageData;
                    response.IsSuccess = true;
                    return response;
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.DomainErrorResponse = "Photo could not be added to user.";
                return response;
            }
        }
    }
}
