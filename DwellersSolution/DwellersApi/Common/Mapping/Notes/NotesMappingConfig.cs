using Dwellers.Notes.Contracts.Requests;
using Dwellers.Notes.Contracts.Responses;
using Dwellers.Notes.Feature.Notes.Commands;
using Dwellers.Notes.Feature.Notes.Queries;
using Mapster;


namespace DwellersApi.Common.Mapping.Notes
{
    public class NotesMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            // Request => Command / Query
            config.NewConfig<AddNoteRequest, AddNoteCommand>();
            //config.NewConfig<AddNoteholderRequest, AddNoteholderCommand>();

            config.NewConfig<GetNoteRequest, GetNoteQuery>();
            config.NewConfig<GetNotesRequest, GetNotesQuery>();

            config.NewConfig<RemoveNoteRequest, RemoveNoteCommand>();

            // Result => Response
            config.NewConfig<AddNoteResult, AddNoteResponse>()
                .Map(dest => dest, src => src.Note);
            //config.NewConfig<AddNoteholderResult, AddNoteholderResponse>()
            //    .Map(dest => dest, src => src.Noteholder);

            config.NewConfig<GetNoteResult, GetNoteResponse>()
                .Map(dest => dest, src => src.Note);
            config.NewConfig<GetNotesResult, GetNotesResponse>()
                .Map(dest => dest.Notes, src => src.Notes);
            config.NewConfig<RemoveNoteResult, RemoveNoteResponse>()
               .Map(dest => dest, src => src);
        }
    }
}
