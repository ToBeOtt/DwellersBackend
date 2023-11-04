using Dwellers.Common.Data.Models.DwellerEvents;
using Dwellers.Common.Data.Models.Notes;
using Dwellers.Notes.Domain.DTO;
using Mapster;
using Microsoft.AspNetCore.Mvc.TagHelpers;

namespace Dwellers.Notes.Mappings
{
    public class NoteMappingService
    {
        private readonly TypeAdapterConfig _config;
        public NoteMappingService(TypeAdapterConfig config)
        {
            _config = config;
        }

        public DbModelDTO MapToPersistence(DbModelDTO domainDTO)
        {
            var persistenceModel = domainDTO.Adapt<DbModelDTO>(_config);
            return persistenceModel;
        }

        public NoteEntity MapToDomain(NoteEntity persistenceModel)
        {
            var domainDTO = persistenceModel.Adapt<NoteEntity>(_config);
            return domainDTO;
        }
    }
}
