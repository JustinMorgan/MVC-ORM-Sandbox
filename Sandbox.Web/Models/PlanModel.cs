using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AutoMapper;

namespace Sandbox.Web.Models
{
    public class PlanModel
    {
        [Required]
        public string Code { get; set; }
        public UserModel User { get; set; }
        public UserModel CurrentUser { get; set; }
        //public CarrierModel Carrier { get; set; }
        //public PlanModel Parent { get; set; }
        public DateTime? DateModified { get; set; }
        //public BrochureModel Brochure { get; set; }
        public ContractRateOptionModel ContractRateOption { get; set; }
        //public IEnumerable<PlanZipCodeModel> Zips { get; set; }
        //public IEnumerable<PlanModel> Revisions { get; set; }
        //public IEnumerable<XmlConfigItemModel> CustomFields { get; set; }
        //public IEnumerable<CustomFieldModel> CustomFieldTemplate { get; set; }
        //public IEnumerable<EnrollmentTypeModel> EnrollmentTypes { get; set; }
        //public IEnumerable<BenefitModel> Benefits { get; set; }
        //public IEnumerable<PlanModel> LinkedPlans { get; set; }

        [IgnoreMap]
        public string OptionName
        {
            get
            {
                return ContractRateOption.Name + " for Plan " + Code;
            }
        }

        public string OptionName2 { get; set; }
    }
}