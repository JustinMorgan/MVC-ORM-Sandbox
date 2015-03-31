using FluentNHibernate.Data;

namespace Sandbox.Domain
{
    public class PhoneInfo : Entity
    {
        public string PhoneNumber { get; set; }
        public PhoneType Type { get; set; }

        public enum PhoneType
        {
            Home,
            Work,
            Mobile
        }
    }
}