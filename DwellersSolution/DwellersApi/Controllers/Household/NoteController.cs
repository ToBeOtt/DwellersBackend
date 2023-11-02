using Dwellers.Notes.Application.Feature.Notes.Commands;
using Dwellers.Notes.Application.Feature.Notes.Queries;
using Dwellers.Notes.Contracts.Requests;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Authentication;

namespace DwellersApi.Controllers.Household
{
    [ApiController]
    [Authorize]
    [Route("notes")]
    public class NoteController : ControllerBase
    {
        private readonly ISender _mediator;

        public NoteController(
            ISender mediator)
        {
            _mediator = mediator;
        }


        //[HttpPost("AddNoteholder")]
        //public async Task<IActionResult> AddNoteholder(AddNoteholderRequest request)
        //{
        //    var houseIdClaim = User.FindFirst("HouseId");

        //    if (houseIdClaim is null)
        //    {
        //        throw new InvalidCredentialException();
        //    }

        //    var cmd = new AddNoteholderCommand(
        //        houseID: new Guid(houseIdClaim.Value),
        //        Category: request.Category,
        //        Name: request.Name,
        //        NoteholderScope: request.NoteholderScope);

        //    var addNoteholderResult = await _mediator.Send(cmd);
        //    return Ok(addNoteholderResult);
            
        //}

        [HttpPost("AddNote")]
        public async Task<IActionResult> AddNote(AddNoteRequest request)
        {
            var userIdClaim = User.FindFirst("UserId");
            var houseIdClaim = User.FindFirst("HouseId");

            if (userIdClaim is null || houseIdClaim is null)
            {
                throw new InvalidCredentialException();
            }
            
            var cmd = new AddNoteCommand(
                Name: request.Name,
                Desc: request.Desc,
                NoteStatus: request.NoteStatus,
                NotePriority: request.NotePriority,
                NoteScope: request.NoteScope,
                Category: request.Category,
                NoteholderId: request.NoteholderId,
                UserId: userIdClaim.Value,
                HouseId: new Guid(houseIdClaim.Value));

            var addNoteResult = await _mediator.Send(cmd);
            return Ok(addNoteResult);
        }

        [HttpGet("GetNote")]
        public async Task<IActionResult> GetNote(Guid noteId)
        {
            var cmd = new GetNoteQuery(
                NoteId: noteId);

            var getNoteResult = await _mediator.Send(cmd);
            return Ok(getNoteResult);
        }

        [HttpGet("GetNotes")]
        public async Task<IActionResult> GetNotes([FromQuery] string? noteCategory)
        {
            var houseIdClaim = User.FindFirst("HouseId");


            if (houseIdClaim is null)
            {
                throw new InvalidCredentialException();
            }

            var cmd = new GetNotesQuery(
                HouseId: new Guid(houseIdClaim.Value),
                NoteCategory: noteCategory is not null && noteCategory != "undefined" ? Convert.ToInt32(noteCategory) : null
                );

            var getNotesResult = await _mediator.Send(cmd);
            return Ok(getNotesResult);
        }


        [HttpGet("GetNoteholder")]
        public async Task<IActionResult> GetNoteholder(Guid noteholderId)
        {
            var houseIdClaim = User.FindFirst("HouseId");

            if (houseIdClaim is null)
            {
                throw new InvalidCredentialException();
            }
            var cmd = new GetNoteholderQuery(
                HouseId: new Guid(houseIdClaim.Value),
                NoteholderId: noteholderId);

            var getNoteholderResult = await _mediator.Send(cmd);
            return Ok(getNoteholderResult);
        }


        [HttpGet("GetNoteholders")]
        public async Task<IActionResult> GetNoteholders()
        {
            var houseIdClaim = User.FindFirst("HouseId");

            if (houseIdClaim is null)
            {
                throw new InvalidCredentialException();
            }

            var cmd = new GetNoteholdersQuery(
                HouseId: new Guid(houseIdClaim.Value));

            var getNoteholdersResult = await _mediator.Send(cmd);
            return Ok(getNoteholdersResult);
        }

        [HttpPost("RemoveNote")]
        public async Task<IActionResult> RemoveNote(RemoveNoteRequest request)
        {
            var cmd = new RemoveNoteCommand(NoteId: request.NoteId);
  
            var RemoveNoteResult = await _mediator.Send(cmd);
            return Ok(RemoveNoteResult);
        }
    }
}