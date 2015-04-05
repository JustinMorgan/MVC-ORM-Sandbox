namespace Sandbox.Domain
{
    public abstract class Entity : IPersistable, IHaveId<long>
    {
        public long Id { get; set; }
    }
}
