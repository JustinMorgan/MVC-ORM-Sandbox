using System;
using System.Collections.Generic;

namespace Sandbox.Domain.Models
{
    public class Carrier : Entity
    {
        //public virtual Dictionary<string, int> Progress { get; protected set; }

        //public virtual Guid ParentId { get; set; }
        public virtual Carrier Parent { get; set; }

        //public virtual int UserId { get; set; }
        public virtual User User { get; set; }

        //public virtual int CurrentUserID { get; set; }
        public virtual User CurrentUser { get; set; }

        //public virtual Guid ContractId { get; set; }
        public virtual Contract Contract { get; set; }

        public virtual string Title { get; set; }
        public virtual string Code { get; set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual DateTime? StartDate { get; set; }
        public virtual DateTime? EndDate { get; set; }
        public virtual bool IsActive { get; set; }
        public virtual DateTime? DateModified { get; set; }
        public virtual StateTerritory State { get; set; }
        public virtual RatingMethod ReconciliationRatingMethod { get; set; }
        public virtual ICollection<XmlConfigItem> CustomFields { get; protected set; }
        public virtual ICollection<CustomField> CustomFieldTemplate { get; protected set; }
        public virtual ICollection<Plan> Plans { get; protected set; }
        public virtual ICollection<Contact> Contacts { get; protected set; }
        public virtual ICollection<CarrierComment> CarrierComments { get; protected set; }
        public virtual ICollection<CarrierSubCode> CarrierSubCodes { get; protected set; }
        public virtual ICollection<CarrierTier> CarrierTiers { get; protected set; }
        public virtual ICollection<Carrier> Revisions { get; protected set; }
        public virtual ICollection<ServiceArea> ServiceAreas { get; protected set; }
    }
}
