using FluentNHibernate.Cfg;
using NHibernate.Cfg;
using NHibernate.Context;
using Sandbox.Persistence.Startup;

namespace Sandbox.Persistence.NHibernate.Startup
{
    public class NHBootstrapper
    {
        private readonly IDatabaseConfigurer _databaseConfigurer;
        private readonly IMappingConfigurer _mappingConfigurer;
        private readonly ISchemaConfigurer _schemaConfigurer;

        public NHBootstrapper(IDatabaseConfigurer databaseConfigurer, IMappingConfigurer mappingConfigurer, ISchemaConfigurer schemaConfigurer)
        {
            _databaseConfigurer = databaseConfigurer;
            _mappingConfigurer = mappingConfigurer;
            _schemaConfigurer = schemaConfigurer;
        }

        public virtual Configuration Configure()
        {
            return Fluently.Configure()
                           .Database(_databaseConfigurer.DefaultConfiguration)
                           .CurrentSessionContext<WebSessionContext>()
                           .Mappings(_mappingConfigurer.AutomapDomainObjects)
                           .ExposeConfiguration(_schemaConfigurer.DefaultUpdateStrategy)
                           .BuildConfiguration();
        }
    }
}
