﻿using Dwellers.Household.Domain.Entities.DwellerHouse;
using Dwellers.Household.Domain.Exceptions;
using Dwellers.Household.Domain.ValueObjects;
using System.Globalization;

namespace Dwellers.Household.Domain.Entities.DwellerServices
{
    public class ProvidedService
    {
        public Guid Id { get; set; }

        public House House { get; set; }
        public Guid HouseId { get; set; }

        public DwellerService DwellerService { get; set; }
        public Guid DwellerServiceId { get; set; }

        public bool IsProvider { get; set; }
        public bool Archived { get; private set; }

        public string? Note { get; set; }
        public DateTime Created { get; set; }
        public bool? ServiceReturned { get; set; }

        public ProvidedService() { }
        public ProvidedService(
            House house,
            DwellerService service,
            string? note)
        {
            Created = DateTime.Now;
            House = house;
            DwellerService = service;
            if (note != null)
            {
                Note = note;
            }
        }

        public void SetArchived(bool isArchived)
        {
            if (IsProvider && isArchived)
            {
                throw new ForbiddenModificationException("A service cannot be archived by its provider.");
            }

            Archived = isArchived;
        }
    }
}
