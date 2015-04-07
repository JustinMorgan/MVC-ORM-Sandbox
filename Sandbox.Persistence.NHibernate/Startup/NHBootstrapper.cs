using FluentNHibernate.Cfg;
using NHibernate.Cfg;
using NHibernate.Context;
using Sandbox.Persistence.Startup;

namespace Sandbox.Persistence.NHibernate.Startup
{
    public class NHBootstrapper
    {
        public static Configuration Configure()
        {
            return Fluently.Configure()
                           .Database(NHDatabaseConfig.DefaultConfiguration)
                           .CurrentSessionContext<WebSessionContext>()
                           .Mappings(NHMappingConfig.AutomapDomainObjects)
                           .ExposeConfiguration(NHSchemaConfig.DefaultUpdateStrategy)
                           .BuildConfiguration();
        }
    }
}
