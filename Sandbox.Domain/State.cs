using FluentNHibernate.Data;

namespace Sandbox.Domain
{
    public class State : Entity
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public Country Country { get; set; }
    }
}