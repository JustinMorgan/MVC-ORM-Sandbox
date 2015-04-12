using System;
using System.Linq;
using System.Reflection;
using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Utils;
using Sandbox.Domain;
using Sandbox.Domain.Annotations;
using Sandbox.Domain.Models;
using Sandbox.Persistence.NHibernate.Startup;

namespace Sandbox.Persistence.Startup
{
    public interface IMappingConfigurer
    {
        void AutomapDomainObjects(MappingConfiguration mapConfig);
    }
    public class NHMappingConfig : IMappingConfigurer
    {
        public virtual void AutomapDomainObjects(MappingConfiguration mapConfig)
        {
            var entityAssembly = Assembly.GetAssembly(typeof(IPersistable));
            var conventionAssembly = Assembly.GetExecutingAssembly();

            var baseAutoMap = MapAllFrom(entityAssembly, conventionAssembly)
                .Where(objectType =>
                    objectType.HasInterface(typeof(IPersistable)));

            mapConfig.AutoMappings.Add(baseAutoMap);
        }

        protected virtual AutoPersistenceModel MapAllFrom(Assembly entityAssembly, Assembly conventionAssembly)
        {
            return new AutoPersistenceModel()
                .AddEntityAssembly(entityAssembly)
                .UseOverridesFromAssemblyOf<NHBootstrapper>()
                .OverrideAll(IgnoreByAttribute<DoNotPersistAttribute>)
                .Conventions.AddAssembly(conventionAssembly);
        }

        private void IgnoreByAttribute<TAttribute>(IPropertyIgnorer propertyIgnorer)
            where TAttribute : Attribute
        {
            propertyIgnorer.IgnoreProperties(x => x.MemberInfo.GetCustomAttribute<TAttribute>(true) != null);
        }
    }
}
