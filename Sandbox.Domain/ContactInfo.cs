using FluentNHibernate.Data;

namespace Sandbox.Domain
{
    public class ContactInfo : Entity
    {
        public string StreetAddress { get; set; }
        public State State { get; set; }
        public string Zip { get; set; }
        public PhoneInfo Phone { get; set; }

        public Country Country
        {
            get { return State.Country; }
        }
    }
}