namespace Sandbox.Domain.Models
{
    public class PhoneInfo : DomainObject
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