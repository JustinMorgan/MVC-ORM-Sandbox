namespace Sandbox.Domain
{
    public abstract class Entity : IPersistable, IHaveId<long>
    {
        public virtual long Id { get; set; }
    }
}
