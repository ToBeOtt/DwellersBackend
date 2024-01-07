using Microsoft.AspNetCore.Http;
using SharedKernel.Domain;

namespace Dwellers.DwellerCore.Domain.Entities.Dwellers
{
    public sealed class Dweller : BaseEntity
    {
        // model properties
        public string Id { get; set; }
        private string _alias;
        private string _email;
        private byte[]? _profilePhoto;

        private bool _isArchived;
        private DateTime _isCreated;
        private DateTime _isModified;

        private Dweller() { }
        private Dweller(
            string id,
            string alias,
            string email)
        {
            Id = id;

            _alias = alias;
            _email = email;

            _isCreated = DateTime.Now;
            _isArchived = false;
        }

        public static class DwellerFactory
        {
            public static async Task<Dweller> Create(
                    string id, string alias, string email)
            {
                var dwelling = new Dweller(id, alias, email);
                return dwelling;
            }
        }

        public async Task<bool> SetProfilePhoto(IFormFile photo)
        {
            try
            {
                using (var memoryStream = new MemoryStream())
                {
                    await photo.CopyToAsync(memoryStream);
                    byte[] imageData = memoryStream.ToArray();

                    _profilePhoto = imageData;
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public string GetAlias()
        {
            return _alias;
        }
        public string GetEmail()
        {
            return _email;
        }
    }
}
