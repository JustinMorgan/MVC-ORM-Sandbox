namespace Sandbox.Domain
{
    public interface IHaveId<TId> where TId : struct
    {
        TId Id { get; set; }
    }
}