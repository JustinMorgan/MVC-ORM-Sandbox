using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Data;
using NHibernate;
using NHibernate.Bytecode;
using NHibernate.Cfg;
using NHibernate.Context;
using NHibernate.Dialect;
using NHibernate.Tool.hbm2ddl;
using Sandbox.Domain;

namespace Sandbox.Persistence.NHibernate
{
    public class NHBootstrapper
    {
        public static Configuration Configure()
        {
            var configuration = CreateConfiguration();

            return Fluently.Configure(configuration)
                .CurrentSessionContext<WebSessionContext>()
                .Mappings(map => map.AutoMappings.Add(GenerateAutomap()))
                .ExposeConfiguration(UpdateSchema)
                .BuildConfiguration();
        }

        private static Configuration CreateConfiguration()
        {
            var configuration = new Configuration();

            configuration.SessionFactory()
                .Proxy.Through<DefaultProxyFactoryFactory>()
                .Integrate.Using<MsSql2008Dialect>()
                .Connected.ByAppConfing("Sandbox");

            return configuration;
        }

        private static AutoPersistenceModel GenerateAutomap()
        {
            AutoPersistenceModel automap = new AutoPersistenceModel();

            automap.Conventions.AddFromAssemblyOf<NHBootstrapper>();
            automap.UseOverridesFromAssemblyOf<NHBootstrapper>();
            automap.AddEntityAssembly(Assembly.GetAssembly(typeof(Person)))
                   .Where(objectType => objectType.IsSubclassOf(typeof(Entity)));

            return automap;
        }

        // Updates the database schema if there are any changes to the model,
        // or drops and creates it if it doesn't exist
        private static void UpdateSchema(Configuration configuration)
        {
            new SchemaUpdate(configuration).Execute(false, true);
        }
    }
}
