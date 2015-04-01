using System;
using FluentNHibernate.Data;

namespace Sandbox.Domain
{
    public class Person : Entity
    {
        public virtual string Name { get; set; }
        public virtual DateTime BirthDate { get; set; }
        public virtual ContactInfo ContactInfo { get; set; }
    }
}
