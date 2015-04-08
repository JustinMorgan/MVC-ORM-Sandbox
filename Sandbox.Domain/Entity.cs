using System;

namespace Sandbox.Domain
{
    public abstract class Entity : IPersistable, IHaveId<long>
    {
        public virtual long Id { get; set; }
    }
    //todo: make entity generic
    public abstract class GuidEntity : IPersistable, IHaveId<Guid>
    {
        public virtual Guid Id { get; set; }
    }
}
