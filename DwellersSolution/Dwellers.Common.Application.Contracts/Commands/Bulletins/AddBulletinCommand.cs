namespace Dwellers.Common.Application.Contracts.Commands.Bulletins
{

    public record AddBulletinCommand(
           string UserId,
           string Title,
           string Text,
           List<string> BulletinTags,
           string BulletinStatus,
           string BulletinPriority,
           string Visibility,
           List<Guid> ChosenHouses);

}
