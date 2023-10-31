using Dwellers.Common.DAL.Models.Common.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dwellers.Common.DAL.Models.DwellerServices
{
    public sealed class DwellerServiceEntity
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        public VisibilityScope ServiceScope { get; private set; }
        public bool ServiceStatus { get; private set; }
        public DateTime? DateAdded { get; private set; }


        public ICollection<ProvidedServiceEntity> ProvidedServices { get; set; }

        public DwellerServiceEntity() { }

    }
}
