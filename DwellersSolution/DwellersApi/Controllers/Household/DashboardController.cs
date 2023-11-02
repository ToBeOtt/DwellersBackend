using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DwellersApi.Controllers.Household
{

    [ApiController]
    [Authorize]
    [Route("dashboard")]
    public class DashboardController : ControllerBase
    {
        private readonly ISender _mediator;

        public DashboardController(
            ISender mediator)
        {
            _mediator = mediator;
        }


        //[HttpGet("GetDashboardNotes")]
        //public async Task<IActionResult> GetDashboardNotes()
        //{
        //    var houseIdClaim = User.FindFirst("HouseId");

        //    if (houseIdClaim is null)
        //    {
        //        throw new InvalidCredentialException();
        //    }

        //    var cmd = new GetDashboardNotesCommand(
        //        HouseId: new Guid(houseIdClaim.Value));

        //    var getDashboardNotesResult = await _mediator.Send(cmd);
        //    return Ok(getDashboardNotesResult);
        //}
    }
}
