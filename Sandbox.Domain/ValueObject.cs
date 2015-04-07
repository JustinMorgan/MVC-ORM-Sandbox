namespace Sandbox.Domain
{
    public abstract class ValueObject<TId> : IHaveId<TId> where TId : struct
    {
        public virtual TId Id { get; set; }
    }
}