using FluentNHibernate.Cfg.Db;

namespace Sandbox.Persistence.Startup
{
    public interface IDatabaseConfigurer
    {
        IPersistenceConfigurer DefaultConfiguration { get; }
    }
    public class NHDatabaseConfig : IDatabaseConfigurer
    {
        public IPersistenceConfigurer DefaultConfiguration
        {
            get
            {
                return MsSqlConfiguration.MsSql2008
                                         .ConnectionString(c => c.FromConnectionStringWithKey("Sandbox")) //todo: remove magic string
                                         .ShowSql();
            }
        }
    }
}
