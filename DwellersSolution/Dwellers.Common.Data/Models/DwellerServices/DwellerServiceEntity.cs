using Dwellers.Common.Data.Models.Common.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dwellers.Common.Data.Models.DwellerServices
{
    public sealed class DwellerServiceEntity
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        public int ServiceScope { get; private set; }
        public bool? ServiceStatus { get; private set; }

        public bool Archived { get; private set; }
        public DateTime IsCreated { get; private set; }
        public DateTime? IsModified { get; private set; }


        public ICollection<ProvidedServiceEntity> ProvidedServices { get; set; }

        public DwellerServiceEntity() { }

    }
}
