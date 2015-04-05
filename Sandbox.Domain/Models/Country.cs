namespace Sandbox.Domain.Models
{
    public class Country : Entity<long>
    {
        public virtual string Name { get; set; }
    }
}