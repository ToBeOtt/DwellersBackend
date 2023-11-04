using SharedKernel.Domain.DomainModels;

namespace Dwellers.Bulletin.Domain.Bulletins
{
    public class BulletinScope : Entity
    {
        private List<Guid> _houseId;
        private bool _visibleToNeighbourhood;
        private bool _global;
        private Guid _bulletinId;

        public static BulletinScope SetNewScope(
            Guid id,
            List<Guid> houseList, 
            bool visibleToNeighbourhood,
            bool global
            )
        {
            return new BulletinScope(id, houseList, visibleToNeighbourhood, global);
        }
        private BulletinScope(
            Guid id,
            List<Guid> houseList,
            bool visibleToNeighbourhood,
            bool global
            )
        {
            _bulletinId = id;


            // Check for houses
            // If house, set other visibility-bools to false
            // Raise event for selected houses that a bulletin has been posted


            _houseId = houseList;

            if(houseList.Count <= 0 || houseList == null)
            {
                if(visibleToNeighbourhood)
                {
                    _visibleToNeighbourhood = visibleToNeighbourhood;
                    _global = false;
                }
                else
                {
                    _global = global;
                    _visibleToNeighbourhood = false;
                }
            }
            
           

            
        }

    }

}
