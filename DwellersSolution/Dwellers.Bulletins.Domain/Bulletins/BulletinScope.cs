using SharedKernel.Domain;
using static Dwellers.Bulletins.Domain.Bulletins.Bulletin;

namespace Dwellers.Bulletins.Domain.Bulletins
{
    public enum Visibility
    {
        Custom,
        Household,
        Neighbourhood,
        Global
    }

    public class BulletinScope : BaseEntity
    {
        public readonly record struct ScopeId(Guid Value);
        private ScopeId _scopeId;

        private BulletinId _bulletinId;
        private List<ScopedHouse> _listOfHouses = new List<ScopedHouse>();
        private Visibility _visibility;

        private BulletinScope() { }
        private BulletinScope(
            BulletinId bulletinId,
            List<Guid>? houseList,
            string visibility
            )
        {
            _scopeId = new ScopeId(Guid.NewGuid());
            _bulletinId = bulletinId;

            foreach(var house in houseList)
            {
                _listOfHouses.Add(new ScopedHouse(_scopeId, house));
            }
            _visibility = Visibility.Custom;
            // Raise event for selected houses that a bulletin has been posted

            if ((houseList.Count <= 0 || houseList == null) && visibility !=  null)
            {
                ConvertVisibilityFromUIValue(visibility);
            }      
        }

        public static class BulletinScopeFactory
        {
            public static BulletinScope SetBulletinScope(
                    BulletinId bulletinId,
                    List<Guid>? houseList,
                    string? visibility
                    )
            {
                return new BulletinScope(bulletinId, houseList, visibility);
            }
        }

        public void ConvertVisibilityFromUIValue(string visibilityValue)
        {
            int parsedValue = Convert.ToInt32(visibilityValue);

            if (Enum.IsDefined(typeof(Visibility), parsedValue))
            {
                _visibility = (Visibility)parsedValue;
            }
            else
            {
                throw new ArgumentException("Invalid value for status");
            }
        }
    }
}
