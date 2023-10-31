using Dwellers.Common.DAL.Models.Household;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dwellers.Common.DAL.Models.Notes
{
    public class HouseNoteholderEntity
    {
        public Guid Id { get; set; }

        public HouseEntity House { get; set; }
        public Guid HouseId { get; set; }

        public NoteholderEntity Noteholder { get; set; }
        public Guid NoteholderId { get; set; }

        public HouseNoteholderEntity() { }
        public HouseNoteholderEntity(HouseEntity house, NoteholderEntity noteholder)
        {
            House = house;
            Noteholder = noteholder;
        }

    }
}
