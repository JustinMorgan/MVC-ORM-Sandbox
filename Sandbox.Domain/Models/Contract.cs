using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sandbox.Domain.Models
{
    public class Contract : Entity
    {
        [Required]
        public virtual string Number { get; set; }

        [Required]
        public virtual FiscalYear FiscalYear { get; set; }

        public virtual DateTime? EndDate { get; set; }
        public virtual bool IsActive { get; set; }

        //public virtual Guid ParentId { get; set; }
        public virtual Contract Parent { get; set; }
        
        public virtual DateTime? DateModified { get; set; }
        public virtual string Name { get; set; }

        //public virtual int CurrentUserId { get; set; }
        public virtual User CurrentUser { get; set; }
        
        //public virtual Guid? RatingTypeId { get; set; }
        public virtual RatingType RatingType { get; set; }

        //public virtual Guid? CompanyId { get; set; }
        public virtual Company Company { get; set; }
        
        public virtual PlanType PlanType { get; set; }
        public virtual BenefitProgram BenefitProgram { get; set; }

        public virtual ICollection<ContractComment> ContractComments { get; protected set; }
        public virtual ICollection<XmlConfigItem> CustomFields { get; protected set; }
        public virtual ICollection<CustomField> CustomFieldTemplate { get; protected set; }
        public virtual ICollection<Contact> Contacts { get; protected set; }
        public virtual ICollection<Carrier> Carriers { get; protected set; }
        public virtual ICollection<Plan> Plans { get; protected set; }
        public virtual ICollection<Contract> Revisions { get; protected set; }

        ////move to repository
        //public static bool NumberExists(string number, Guid contractId)
        //{
        //    var data = new Data.Contract();
        //    return data.NumberExists(number, contractId);
        //}
    }
}