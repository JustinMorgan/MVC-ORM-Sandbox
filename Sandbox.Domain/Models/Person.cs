using System;
using Sandbox.Domain.Annotations;

namespace Sandbox.Domain.Models
{
    public class Person : DomainObject
    {
        public virtual string Name { get; set; }
        public virtual DateTime BirthDate { get; protected set; }
        public virtual ContactInfo ContactInfo { get; set; }
        public virtual GenderType Gender { get; set; }

        internal protected Person()
        {
            
        }

        public Person(string name, DateTime birthDate, ContactInfo contactInfo, GenderType gender)
        {
            Name = name;
            BirthDate = birthDate;
            ContactInfo = contactInfo;
            Gender = gender;
        }

        [DoNotPersist]
        public virtual void ChangeBirthdate(DateTime newDate)
        {
            if (Name != "Guy who always changes his birthdate")
            {
                BirthDate = newDate;
            }
        }

        public enum GenderType
        {
            Male,
            Female
        }
    }
}
