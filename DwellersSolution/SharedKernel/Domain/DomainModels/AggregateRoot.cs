using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SharedKernel.Domain.DomainModels
{
   public abstract class AggregateRoot<TId> : Entity<TId> 
        where TId : notnull
    {
        protected AggregateRoot(TId id) : base(id)
        {

        }
    }
}
