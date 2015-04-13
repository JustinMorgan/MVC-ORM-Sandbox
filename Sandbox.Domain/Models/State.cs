namespace Sandbox.Domain.Models
{
    public class State : Entity
    {
        public virtual string Name { get; set; }
        public virtual string Code { get; set; }
        public virtual Country Country { get; set; }
    }
}