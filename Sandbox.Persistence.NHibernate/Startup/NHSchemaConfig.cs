using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;

namespace Sandbox.Persistence.Startup
{
    public interface ISchemaConfigurer
    {
        void DefaultUpdateStrategy(Configuration configuration);
    }
    public class NHSchemaConfig : ISchemaConfigurer
    {
        public virtual void DefaultUpdateStrategy(Configuration configuration)
        {
            // Updates the database schema if there are any changes to the model,
            // or drops and creates it if it doesn't exist
            new SchemaUpdate(configuration).Execute(false, true);
        }
    }
}
