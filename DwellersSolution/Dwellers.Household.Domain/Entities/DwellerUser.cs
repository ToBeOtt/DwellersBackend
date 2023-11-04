using Microsoft.AspNetCore.Http;
using Microsoft.Graph.Models;
using SharedKernel.Domain.DomainModels;
using SharedKernel.Domain.DomainResponse;
using System.Threading;

namespace Dwellers.Household.Domain.Entities
{
    public sealed class DwellerUser : BaseEntity
    {
        public string Alias { get; set; }
        public string Email { get; set; }
        public byte[]? ProfilePhoto { get; set; }

        public DwellerUser() 
        {
            Id = Guid.NewGuid();
            IsCreated = DateTime.Now;
            IsArchived = false;
        }

        public DwellerUser(string alias, string email)
        {
            Id = Guid.NewGuid();
            Alias = alias;
            Email = email;

            IsCreated = DateTime.Now;
            IsArchived = false;
        }

        public async Task<DomainResponse<bool>> SetProfilePhoto(IFormFile photo)
        {
            DomainResponse<bool> response = new();

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
