namespace Sandbox.Domain.Models
{
    public class State : ValueObject
    {
        public virtual string Name { get; set; }
        public virtual string Code { get; set; }
        public virtual Country Country { get; set; }
    }
}