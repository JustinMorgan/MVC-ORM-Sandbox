using System;
using System.Collections.Generic;
using Sandbox.Domain.Annotations;

namespace Sandbox.Domain.Models
{
    public class Plan : Entity
    {
        public virtual string Code { get; set; }
        //public virtual Guid ParentId { get; set; }

        //public virtual int UserId { get; set; }
        public virtual User User { get; set; }

        //public virtual int CurrentUserID { get; set; }
        public virtual User CurrentUser { get; set; }

        //public virtual Guid CarrierId { get; set; }
        public virtual Carrier Carrier { get; set; }

        //public virtual Guid ParentId { get; set; }
        public virtual Plan Parent { get; set; }

        public virtual DateTime? DateModified { get; set; }
        public virtual Brochure Brochure { get; set; }
        public virtual ContractRateOption ContractRateOption { get; set; }
        public virtual ICollection<PlanZipCode> Zips { get; protected set; }
        public virtual ICollection<Plan> Revisions { get; protected set; }
        public virtual ICollection<XmlConfigItem> CustomFields { get; protected set; }
        public virtual ICollection<CustomField> CustomFieldTemplate { get; protected set; }
        public virtual ICollection<EnrollmentType> EnrollmentTypes { get; protected set; }
        public virtual ICollection<Benefit> Benefits { get; protected set; }
        public virtual ICollection<Plan> LinkedPlans { get; protected set; }

        ////move to ViewModel
        //[DoNotPersist]
        //public string OptionName
        //{
        //    get
        //    {
        //        return ContractRateOption.Name + " for Plan " + Code;
        //    }
        //}
    }
}
