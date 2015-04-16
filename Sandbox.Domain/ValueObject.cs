namespace Sandbox.Domain
{
    public abstract class ValueObject : IHaveId<int>
    {
        public virtual int Id { get; set; }
    }
}