namespace Dwellers.Notes.Feature.Notes.Commands
{

    //public record AddNoteholderCommand(
    //   Guid houseID,
    //   string? Category,
    //   string? NoteholderScope,
    //   string Name) : IRequest<AddNoteholderResult>;

    //public record AddNoteholderResult(
    //    NoteholderEntity Noteholder
    //);

    //public class AddNoteholderCommandHandler : IRequestHandler<AddNoteholderCommand, AddNoteholderResult>
    //{
    //    private readonly ILogger<AddNoteholderCommandHandler> _logger;
    //    private readonly ICommonHouseServices _houseServices;
    //    private readonly INoteCommandRepository _noteCommandRepository;

    //    public AddNoteholderCommandHandler(
    //        ILogger<AddNoteholderCommandHandler> logger,
    //        ICommonHouseServices houseServices,
    //        INoteCommandRepository noteCommandRepository
    //        )
    //    {
    //        _logger = logger;
    //        _houseServices = houseServices;
    //        _noteCommandRepository = noteCommandRepository;
    //    }

    //public async Task<AddNoteholderResult> Handle(AddNoteholderCommand cmd, CancellationToken cancellationToken)
    //{
    //    var house = await _houseServices.GetHouseForOtherServicesById(cmd.houseID);
    //    if (house == null)
    //    {
    //        _logger.LogInformation("Could not find house");
    //    }

    //    var noteholder = new NoteholderEntity(cmd);

    //    if (!await _noteCommandRepository.AddNoteholder(noteholder))
    //    {
    //        _logger.LogInformation("Could not persist noteholder to database");
    //    }

    //    var houseNoteholder = new HouseNoteholderEntity(house, noteholder);
    //    if (!await _noteCommandRepository.AddHouseNoteholder(houseNoteholder))
    //    {
    //        _logger.LogInformation("Could not attach house to note");
    //    }

    //    return new AddNoteholderResult(noteholder);
    //}
    //}
}
