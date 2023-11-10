namespace Dwellers.Bulletins.Contracts.Request
{
    public class BulletinRequests
    {
        public record AddBulletinRequest(
          string Name,
          string Desc,
          string BulletinPriority,
          string BulletinStatus,
          List<string> BulletinTags,
          List<Guid>? ChosenHouses,
          string Visibility);
            
    }
}
