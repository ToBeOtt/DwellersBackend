using Dwellers.Bulletins.Domain.Bulletins;

namespace Dwellers.Common.Application.Interfaces.Bulletins
{
    public interface IBulletinQueryRepository
    {
        Task<Bulletin> GetById(Guid id);
    }
}
