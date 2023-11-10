﻿using Dwellers.Bulletins.Domain.Bulletins.Rules;
using SharedKernel.Domain.DomainModels;

namespace Dwellers.Bulletins.Domain.Bulletins
{
    public enum Priority
    {
        Low,
        Medium,
        High
    }

    public class BulletinPriority : ValueObject
    {
        private Priority _priority;

        public BulletinPriority() { }
        private BulletinPriority(string strPriority)
        {
            CheckRule(new StringIsNotNull(strPriority));
            var priority = ConvertPriorityFromUIValue(strPriority);
            _priority = priority;
        }

        public static class BulletinPriorityFactory
        {
            public static BulletinPriority CreateNewPriority(string strPriority)
            {
                return new BulletinPriority(strPriority);
            }
        }

        public void ConvertPriorityFromDbValue(int dbValue)
        {
            if (Enum.IsDefined(typeof(Priority), dbValue))
            {
                _priority = (Priority)dbValue;
            }
            else
            {
                throw new ArgumentException("Invalid value for status");
            }
        }
        public static Priority ConvertPriorityFromUIValue(string uiValue)
        {
            if (int.TryParse(uiValue, out int parsedvalue) && Enum.IsDefined(typeof(Priority), parsedvalue))
            {
                return (Priority)parsedvalue;
            }
            throw new ArgumentException("Invalid value for priority");
        }
    }
}
