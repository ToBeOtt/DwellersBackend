using static Dwellers.Bulletins.Domain.Bulletins.BulletinScope;

namespace Dwellers.Bulletins.Domain.Bulletins
{
    public class ScopedHouse
    {
        private ScopeId _bulletinScopeId;
        private Guid _scopedHouseId;

        private ScopedHouse() { }
        internal ScopedHouse(ScopeId bulletinScopeId, Guid scopedHouseId)
        {
            _bulletinScopeId = bulletinScopeId;
            _scopedHouseId = scopedHouseId;
        }
    }
}
