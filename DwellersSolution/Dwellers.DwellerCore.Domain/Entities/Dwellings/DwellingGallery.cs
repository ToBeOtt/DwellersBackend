using Microsoft.AspNetCore.Http;
using SharedKernel.Domain;
using static Dwellers.DwellerCore.Domain.Entities.Dwellings.Dwelling;

namespace Dwellers.DwellerCore.Domain.Entities.Dwellings
{
    public class DwellingGallery : ValueObject
    {
        private byte[] _dwellingImage;
        private DwellingId _dwellingId;

        private DwellingGallery() { }
        private DwellingGallery(byte[] image, DwellingId dwellingId)
        {
            _dwellingImage = image;
            _dwellingId = dwellingId;
        }

        internal static DwellingGallery CreateNewGalleryEntryFactory(IFormFile image, DwellingId dwellingId)
        {
            try
            {
                using (var memoryStream = new MemoryStream())
                {
                    image.CopyToAsync(memoryStream);
                    byte[] imageData = memoryStream.ToArray();

                    return new DwellingGallery(imageData, dwellingId);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
