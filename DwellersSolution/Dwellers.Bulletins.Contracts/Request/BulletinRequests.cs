namespace Dwellers.Bulletins.Contracts.Request
{
    public class BulletinRequests
    {
        public record AddBulletinRequest(
          string Title,
          string Text,
          List<string> BulletinTags,
          string BulletinStatus,
          string BulletinPriority,
          string Visibility,
          List<Guid>? ChosenHouses
          );
            
    }
}

