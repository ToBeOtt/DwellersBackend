using Dwellers.Household.Application.Features.Household.Notes.Commands.AddNote;
using Dwellers.Household.Application.Features.Household.Notes.Commands.AddNoteholder;
using Dwellers.Household.Application.Features.Household.Notes.Commands.RemoveNote;
using Dwellers.Household.Application.Features.Household.Notes.Queries.GetNote;
using Dwellers.Household.Application.Features.Household.Notes.Queries.GetNoteholder;
using Dwellers.Household.Application.Features.Household.Notes.Queries.GetNoteholders;
using Dwellers.Household.Application.Features.Household.Notes.Queries.GetNotes;
using Dwellers.Household.Contracts.Requests.Household.Notes;
using Dwellers.Household.Contracts.Responses.Household.Notes;
using Mapster;


namespace DwellersApi.Common.Mapping.Household.Notes
{
    public class NotesMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            // Request => Command / Query
            config.NewConfig<AddNoteRequest, AddNoteCommand>();
            config.NewConfig<AddNoteholderRequest, AddNoteholderCommand>();

            config.NewConfig<GetNoteRequest, GetNoteQuery>();
            config.NewConfig<GetNotesRequest, GetNotesQuery>();
            config.NewConfig<GetNoteholdersRequest, GetNoteholdersQuery>();

            config.NewConfig<GetNoteholdersRequest, GetNoteholdersQuery>();

            config.NewConfig<RemoveNoteRequest, RemoveNoteCommand>();

            // Result => Response
            config.NewConfig<AddNoteResult, AddNoteResponse>()
                .Map(dest => dest, src => src.Note);
            config.NewConfig<AddNoteholderResult, AddNoteholderResponse>()
                .Map(dest => dest, src => src.Noteholder);

            config.NewConfig<GetNoteResult, GetNoteResponse>()
                .Map(dest => dest, src => src.Note);
            config.NewConfig<GetNotesResult, GetNotesResponse>()
                .Map(dest => dest.Notes, src => src.Notes);
            config.NewConfig<GetNoteholderResult, GetNoteholderResponse>()
                .Map(dest => dest, src => src.Noteholder)
                .Map(dest => dest, src => src.Notes);
            config.NewConfig<GetNoteholdersResult, GetNoteholdersResponse>()
                .Map(dest => dest.Noteholders, src => src.Noteholders);

            config.NewConfig<RemoveNoteResult, RemoveNoteResponse>()
               .Map(dest => dest, src => src);
        }
    }
}
