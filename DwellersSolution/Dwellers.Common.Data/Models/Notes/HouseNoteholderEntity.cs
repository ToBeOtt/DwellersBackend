using Dwellers.Common.Data.Models.Household;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dwellers.Common.Data.Models.Notes
{
    public class HouseNoteholderEntity
    {
        public Guid Id { get; set; }

        public HouseEntity House { get; set; }
        public Guid HouseId { get; set; }

        public NoteholderEntity Noteholder { get; set; }
        public Guid NoteholderId { get; set; }

        public bool Archived { get; private set; }
        public DateTime IsCreated { get; private set; }
        public DateTime? IsModified { get; private set; }

        public HouseNoteholderEntity() { }
        public HouseNoteholderEntity(HouseEntity house, NoteholderEntity noteholder)
        {
            House = house;
            Noteholder = noteholder;
        }

    }
}
