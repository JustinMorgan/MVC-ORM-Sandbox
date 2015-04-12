using System;

namespace Sandbox.Domain
{
    public abstract class Entity : IPersistable, IHaveId<Guid>
    {
        public virtual Guid Id { get; set; }
    }
}
