using FluentNHibernate.Data;

namespace Sandbox.Domain.Models
{
    public class Country : Entity
    {
        public virtual string Name { get; set; }
    }
}