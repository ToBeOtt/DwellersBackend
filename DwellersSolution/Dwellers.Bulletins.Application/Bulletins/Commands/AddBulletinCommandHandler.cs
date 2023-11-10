using Dwellers.Bulletins.Domain.Bulletins;
using Microsoft.Extensions.Logging;
using SharedKernel.Application.ServiceResponse;
using SharedKernel.Infrastructure.Configuration.Commands;
using static Dwellers.Bulletins.Domain.Bulletins.BulletinPriority;
using static Dwellers.Bulletins.Domain.Bulletins.BulletinStatus;

namespace Dwellers.Bulletins.Application.Bulletins.Commands
{

    public record AddSomethingCommand(
        string UserId,
        string Title,
        string Text,
        List<string> BulletinTags,
        string BulletinStatus,
        string BulletinPriority,
        string BulletinScope,
        string Visibility,
        List<Guid> ChosenHouses);

    public record AddSomethingResult(
       bool result);
    internal class TestHandler : ICommandHandler<AddSomethingCommand, AddSomethingResult>
    {
        private readonly ILogger<TestHandler> _logger;

        public TestHandler(ILogger<TestHandler> logger)
        {
            _logger = logger;
        }

        //public async Task Handle(AddSomethingCommand cmd, CancellationToken cancellation)
        //{

        //    try
        //    {
        //        var bulletin = Bulletin.BulletinPostFactory.CreateNewBulletin(
        //                            cmd.UserId,
        //                            cmd.Title,
        //                            cmd.Text,
        //                            cmd.BulletinTags,
        //                            BulletinPriorityFactory.CreateNewPriority(cmd.BulletinPriority),
        //                            BulletinStatusFactory.CreateNewStatus(cmd.BulletinStatus),
        //                            cmd.ChosenHouses,
        //                            cmd.Visibility);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }

        //}

        public async Task<ServiceResponse<AddSomethingResult>> Handle
            (AddSomethingCommand cmd, CancellationToken cancellation)
        {
            ServiceResponse<AddSomethingResult> response = new();
            try
            {
                var bulletin =  Bulletin.BulletinPostFactory.CreateNewBulletin(
                                    cmd.UserId,
                                    cmd.Title,
                                    cmd.Text,
                                    cmd.BulletinTags,
                                    BulletinPriorityFactory.CreateNewPriority(cmd.BulletinPriority),
                                    BulletinStatusFactory.CreateNewStatus(cmd.BulletinStatus),
                                    cmd.ChosenHouses,
                                    cmd.Visibility);
                
                return await response.SuccessResponse(response, new AddSomethingResult(true));
            }
            catch (Exception ex)
            {
                return await response.ErrorResponse(response,"Message from handler", _logger, ex.Message);
            }

        }
    }
}

