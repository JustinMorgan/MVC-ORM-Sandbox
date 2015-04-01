using FluentNHibernate.Data;

namespace Sandbox.Domain
{
    public class Country : Entity
    {
        public virtual string Name { get; set; }
    }
}