using System;
using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;
using FluentNHibernate.Utils;
using Sandbox.Domain;

namespace Sandbox.Persistence.Conventions
{
    public class UseGuidCombConvention : IIdConvention
    {
        public void Apply(IIdentityInstance instance)
        {
            if (instance.EntityType.HasInterface(typeof(IHaveId<Guid>)))
            {
                instance.GeneratedBy.GuidComb();
            }
        }
    }
}