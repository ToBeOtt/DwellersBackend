﻿using Microsoft.Graph.Identity.B2xUserFlows.Item.Languages.Item.OverridesPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedKernel.Domain.DomainModels
{
    public abstract class ValueObject : IEquatable<ValueObject>
    {

        public abstract IEnumerable<object> GetEqualityComponents();
        public override bool Equals(object? obj)
        {
            if (obj is null || obj.GetType() != GetType())
            {
                return false;
            }

            var valueObject = (ValueObject)obj;
            return GetEqualityComponents().
                SequenceEqual(valueObject.GetEqualityComponents());
        }
        public static bool operator ==(ValueObject left, ValueObject right)
        {
            return Equals(left, right);
        }
        public static bool operator !=(ValueObject left, ValueObject right)
        {
            return !Equals(left, right);
        }

        public override int GetHashCode()
        {
            return GetEqualityComponents()
                .Select(x => x?.GetHashCode() ?? 0)
                .Aggregate((x, y) => y ^ x);
        }

        public bool Equals(ValueObject? other)
        {
            return Equals((object?)other);
        }
    }
}