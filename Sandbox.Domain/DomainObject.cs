using System;

namespace Sandbox.Domain
{
    public abstract class DomainObject : IPersistable, IHaveId<Guid>
    {
        public virtual Guid Id { get; set; }
    }
}
