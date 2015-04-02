using FluentNHibernate.Data;

namespace Sandbox.Domain.Models
{
    public class ContactInfo : Entity
    {
        public virtual string StreetAddress { get; set; }
        public virtual State State { get; set; }
        public virtual string Zip { get; set; }
        public virtual PhoneInfo Phone { get; set; }

        [IgnoreMap]
        public virtual Country Country
        {
            get { return State.Country; }
        }
    }
}