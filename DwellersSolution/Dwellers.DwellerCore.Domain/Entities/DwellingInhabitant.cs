using SharedKernel.Domain;
using static Dwellers.DwellerCore.Domain.Entities.Dwellings.Dwelling;

namespace Dwellers.DwellerCore.Domain.Entities
{
    public class DwellingInhabitant : ValueObject
    {
        private Guid _dwellingInhabitantId;
        private string _dwellerId;
        private DwellingId _dwellingId;

        private DwellingInhabitant() { }
        internal DwellingInhabitant(string dwellerUserId, DwellingId dwellingId)
        {
            _dwellingInhabitantId = Guid.NewGuid();

            // Check for Duplicate name in dwelling-roster
            _dwellerId = dwellerUserId;
            _dwellingId = dwellingId;
        }

        public static class DwellingInhabitantFactory
        {
            public static async Task<DwellingInhabitant> Create(
                    string dwellerUserId,
                    DwellingId DwellingId
                    )
            {
                return new DwellingInhabitant(dwellerUserId, DwellingId);
            }
        }
    }
}
