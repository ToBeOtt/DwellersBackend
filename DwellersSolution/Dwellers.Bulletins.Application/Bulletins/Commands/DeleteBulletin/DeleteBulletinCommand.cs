using static Dwellers.Bulletins.Domain.Bulletins.Bulletin;

namespace Dwellers.Bulletins.Application.Bulletins.Commands.DeleteBulletin
{
    public record DeleteBulletinCommand
    (
        BulletinId Id
    );
}
