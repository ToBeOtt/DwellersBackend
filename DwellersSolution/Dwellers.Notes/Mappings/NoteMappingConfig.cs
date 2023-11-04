using Dwellers.Common.Data.Models.Notes;
using Dwellers.Notes.Domain.DTO;
using Mapster;

namespace Dwellers.Calendar.Mappings
{
    public class NoteMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<DbModelDTO, NoteEntity>()
                .Map(dest => dest, src => src);
        }
    }
}
