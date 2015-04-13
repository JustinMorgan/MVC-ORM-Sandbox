namespace Sandbox.Domain.Models
{
    public class PhoneInfo : Entity
    {
        public virtual string PhoneNumber { get; set; }
        public virtual PhoneType Type { get; set; }

        public enum PhoneType
        {
            Home,
            Work,
            Mobile
        }
    }
}