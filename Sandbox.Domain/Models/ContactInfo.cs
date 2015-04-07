using Sandbox.Domain.Annotations;

namespace Sandbox.Domain.Models
{
    //todo: model in MVC
    public class ContactInfo : Entity
    {
        public virtual string StreetAddress { get; set; }
        public virtual State State { get; set; }
        public virtual string Zip { get; set; }
        public virtual PhoneInfo Phone { get; set; }

        [DoNotPersist]
        public virtual Country Country
        {
            get { return State.Country; }
        }
    }
}