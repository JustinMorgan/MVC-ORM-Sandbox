using System;
using FluentNHibernate.Data;

namespace Sandbox.Domain.Models
{
    public class Person : Entity
    {
        public virtual string Name { get; set; }
        public virtual DateTime BirthDate { get; set; }
        public virtual ContactInfo ContactInfo { get; set; }
        public virtual GenderType Gender { get; set; }

        public enum GenderType
        {
            Male,
            Female
        }
    }
}
