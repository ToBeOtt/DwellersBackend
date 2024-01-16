using Dwellers.DwellerCore.Domain.DomainServices;
using Microsoft.AspNetCore.Http;
using SharedKernel.Domain;
using SharedKernel.ServiceResponse;

namespace Dwellers.DwellerCore.Domain.Entities.Dwellings
{
    public sealed class Dwelling : BaseEntity, IAggregateRoot
    {
        // Response and services
        private GetAllDwellingNames _getNames;


        // model properties
        public readonly record struct DwellingId(Guid Value);

        public DwellingId Id;
        private Guid _invitationCode;
        private string _name;
        private string? _description;
        private byte[] _dwellingProfilePhoto;
        private List<DwellingGallery> _dwellingGallery;

        private List<DwellingInhabitant> _dwellingInhabitantList;

        private bool _isArchived;
        private DateTime _isCreated;
        private DateTime _isModified;

        private Dwelling() { }
        private Dwelling(
            string name,
            string? description)
        {
            Id = new DwellingId(Guid.NewGuid());
            
            _name = name;
            _description = description;

            _isCreated = DateTime.Now;
            _isArchived = false;
            _invitationCode = Guid.NewGuid();
        }

        public static class DwellingFactory
        {
            public static async Task<Dwelling> Create(
                    string name, string? description)
            {
                var dwelling = new Dwelling(name, description);
                await dwelling.ValidateName(name);
                return dwelling;
            }
        }

        internal async Task<bool> ValidateName(string name)
        {
            var existingNames = await _getNames.FetchAllDwellingNames();
            if (!existingNames.Contains(name))
            {
                _name = name;
                return true;
            }
            else
            return false;
        }

        protected async Task<bool> SetHousePhoto(IFormFile photo)
        {
            DwellerResponse<bool> response = new();

            try
            {
                using (var memoryStream = new MemoryStream())
                {
                    await photo.CopyToAsync(memoryStream);
                    byte[] imageData = memoryStream.ToArray();

                    _dwellingProfilePhoto = imageData;
                    response.IsSuccess = true;
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public string GetName()
        {
            return _name;
        }

        public string GetDescription()
        {
            return _description;
        }
        
        public DwellingGallery AddImageToGallery(IFormFile image)
        {
            var galleryImage = DwellingGallery.CreateNewGalleryEntryFactory(image, this.Id);
            return galleryImage;
        }
    }
}
