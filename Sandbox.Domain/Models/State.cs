namespace Sandbox.Domain.Models
{
    public class State : Entity<long>
    {
        public virtual string Name { get; set; }
        public virtual string Code { get; set; }
        public virtual Country Country { get; set; }
    }
}